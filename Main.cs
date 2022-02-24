using System;
using System.Diagnostics;
using System.IO;
using MelonLoader;
using Console = System.Console;

namespace ConsoleTitleHider {
    public static class BuildInfo {
        public const string Name = "ConsoleTitleHider";
        public const string Author = "Lily";
        public const string Company = null;
        public const string Version = "2.0.0";
        public const string DownloadLink = "https://github.com/MintLily/ConsoleTitleHider";
        public const string Description = "Applies a title change for the MelonLoader Console Window.";
    }

    public class Main : MelonMod {
        private MelonPreferences_Category ModCategory;
        private MelonPreferences_Entry<string> CustomTitleText;
        private readonly MelonLogger.Instance Logger = new MelonLogger.Instance(BuildInfo.Name, ConsoleColor.DarkYellow);
        private string _titleString;

        private static (string publisher, string game) GetPublisherAndGameTitle() {
            string appInfoPath = Path.Combine(MelonUtils.GetGameDataDirectory(), "app.info");
            string appInfo = File.ReadAllText(appInfoPath);
            string[] appInfoLines = appInfo.Split('\n');
            return (appInfoLines[0], appInfoLines[1]);
        }

        readonly (string publisher, string game) _titleData = GetPublisherAndGameTitle();

        private string GetFormattedTitleText() {
            string constructedText = MelonPreferences.GetEntry<string>(ModCategory.Identifier, CustomTitleText.Identifier).Value;
            constructedText = constructedText.Replace("{PUBLISHER}", _titleData.publisher);  
            constructedText = constructedText.Replace("{GAME}", _titleData.game);
            return constructedText;
        }

        public override void OnApplicationStart() {
            ModCategory = MelonPreferences.CreateCategory("CustomConsoleTitle", "CustomConsoleTitle");
            CustomTitleText = ModCategory.CreateEntry("TitleText", "Being a Cutie!", "Title Text",
                "Text to show on the Console Window Title");
            _titleString = GetFormattedTitleText();
            Console.Title = string.Format(_titleString);
            Logger.Msg($"Set console title to: {_titleString}");
        }

        public override void OnPreferencesSaved() {
            // Highly recommend using UIExpansionKit to easily change your title (For VRChat)
            _titleString = GetFormattedTitleText();
            Console.Title = string.Format(_titleString);
            Logger.Msg($"Set console title to: {_titleString}");
        }
    }
}