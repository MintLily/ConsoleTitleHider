using System.Diagnostics;
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

        public override void OnApplicationStart() {
            p = Process.GetProcessesByName("XSOverlay");
            if (p.Length >= 1) {
                MelonPrefs.RegisterCategory(ModCategory, "Custom Console Title");
                MelonPrefs.RegisterString(ModCategory, CustomTitleText, "Being a Cutie!", "Custom Console Text");
                TitleString = MelonPrefs.GetString(ModCategory, CustomTitleText);
                Console.Title = string.Format(TitleString);
                Started = true;
            }
        }

        public override void OnModSettingsApplied() {
           if (Started) {
                // Highly recommend using UIExpansionKit to easily change your title (For VRChat)
                TitleString = MelonPrefs.GetString(ModCategory, CustomTitleText);
                Console.Title = string.Format(TitleString);
                MelonLogger.Log("Set console title to: " + TitleString);
           }
        }
    }
}