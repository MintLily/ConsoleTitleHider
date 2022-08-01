using System;
using System.IO;
using System.Runtime.InteropServices;
using MelonLoader;
using Console = System.Console;

namespace ConsoleTitleHider;
public static class BuildInfo {
    public const string Name = "ConsoleTitleHider";
    public const string Author = "Lily";
    public const string Company = "Minty Labs";
    public const string Version = "2.0.1";
    public const string DownloadLink = "https://github.com/MintLily/ConsoleTitleHider";
    public const string Description = "Applies a title change for the MelonLoader Console Window and/or Game Window.";
}
public class Main : MelonMod {
    private MelonPreferences_Category _modCategory;
    private MelonPreferences_Entry<string> _customTitleText;
    private MelonPreferences_Entry<bool> _changeGameWindowText;
    private readonly MelonLogger.Instance _logger = new (BuildInfo.Name, ConsoleColor.DarkYellow);
    private string _titleString;

    private static (string publisher, string game) GetPublisherAndGameTitle() {
        var appInfoPath = Path.Combine(MelonUtils.GetGameDataDirectory(), "app.info");
        var appInfo = File.ReadAllText(appInfoPath);
        var appInfoLines = appInfo.Split('\n');
        return (appInfoLines[0], appInfoLines[1]);
    }

    private readonly (string publisher, string game) _titleData = GetPublisherAndGameTitle();

    private string GetFormattedTitleText() {
        var constructedText = MelonPreferences.GetEntry<string>(_modCategory.Identifier, _customTitleText.Identifier).Value;
        constructedText = constructedText.Replace("{PUBLISHER}", _titleData.publisher);  
        constructedText = constructedText.Replace("{GAME}", _titleData.game);
        return constructedText;
    }
    
    [DllImport("user32.dll", EntryPoint = "SetWindowText")]
    private static extern bool SetWindowText(IntPtr hwnd, String lpString);
    
    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    private static extern IntPtr FindWindow(String className, String windowName);

    private IntPtr _gameWindow;

    public override void OnApplicationStart() {
        _modCategory = MelonPreferences.CreateCategory("CustomConsoleTitle", "CustomConsoleTitle");
        _customTitleText = _modCategory.CreateEntry("TitleText", "Being a Cutie!", "Title Text",
            "Text to show on the Console Window Title");
        _changeGameWindowText = _modCategory.CreateEntry("changeGameWindowText", false, "Change Game Window Title",
            "Change the Game Window Title");
        
        _titleString = GetFormattedTitleText();
        Console.Title = string.Format(_titleString);
        
        if (_changeGameWindowText.Value) {
            _gameWindow = FindWindow(null, _titleData.game);
            SetWindowText(_gameWindow, _titleString);
        }
        
        _logger.Msg($"Set console title to: {_titleString}");
    }

    public override void OnPreferencesSaved() {
        // Highly recommend using UIExpansionKit to easily change your title (For VRChat or ChilloutVR)
        _titleString = GetFormattedTitleText();
        Console.Title = string.Format(_titleString);
        
        if (_changeGameWindowText.Value) {
            _gameWindow = FindWindow(null, _titleData.game);
            SetWindowText(_gameWindow, _titleString);
        }
        
        _logger.Msg($"Set console title to: {_titleString}");
    }
}