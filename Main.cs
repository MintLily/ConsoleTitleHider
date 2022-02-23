using System.Diagnostics;
using System.IO;
using MelonLoader;
using Console = System.Console;

namespace XSOverlayTitleHider {
    public static class BuildInfo {
        public const string Name = "XSOverlayTitleHider"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "Lily"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.5.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://github.com/MintLily/XSOverlayTitleHider"; // Download Link for the Mod.  (Set as null if none)
        public const string Description = "Applies a title change for the MelonLoader Console Window, hiding it from XSOverlay.";
    }

    public class XSOverlayTitleHider : MelonMod {
        private const string ModCategory = "CustomConsoleTitle";
        private const string CustomTitleText = "TitleText";
        private string TitleString;
        private Process[] p;
        private bool Started;

        private static (string publisher, string game) GetPublisherAndGameTitle()
        {
            string appInfoPath = Path.Combine(MelonUtils.GetGameDataDirectory(), "app.info");
            string appInfo = File.ReadAllText(appInfoPath);
            string[] appInfoLines = appInfo.Split('\n');
            return (appInfoLines[0], appInfoLines[1]);
        }

        readonly (string publisher, string game) _titleData = GetPublisherAndGameTitle();

        private string GetFormattedTitleText()
        {
            string constructedText = MelonPrefs.GetString(ModCategory, CustomTitleText);
            constructedText = constructedText.Replace("{PUBLISHER}", _titleData.publisher);  
            constructedText = constructedText.Replace("{GAME}", _titleData.game);
            return constructedText;
        }

        public override void OnApplicationStart() {
            p = Process.GetProcessesByName("XSOverlay");
            if (p.Length >= 1) {
                MelonPrefs.RegisterCategory(ModCategory, "Custom Console Title");
                MelonPrefs.RegisterString(ModCategory, CustomTitleText, "Being a Cutie!", "Custom Console Text");
                TitleString = GetFormattedTitleText();
                Console.Title = string.Format(TitleString);
                Started = true;
            }
        }

        public override void OnModSettingsApplied() {
           if (Started) {
                // Highly recommend using UIExpansionKit to easily change your title (For VRChat)
                TitleString = GetFormattedTitleText();
                Console.Title = string.Format(TitleString);
                MelonLogger.Log("Set console title to: " + TitleString);
           }
        }
    }
}