using MelonLoader;
using System.ComponentModel;
using Console = System.Console;

namespace XSOverlayTitleHider
{
    public static class BuildInfo
    {
        public const string Name = "XSOverlayTitleHider"; // Name of the Mod.  (MUST BE SET)
        public const string Author = "KortyBoi"; // Author of the Mod.  (Set as null if none)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.2.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = "https://github.com/KortyBoi/XSOverlayTitleHider"; // Download Link for the Mod.  (Set as null if none)
        public const string Description = "Applies a title change for the MelonLoader Console Window, hiding it from XSOverlay.";
    }

    public class XSOverlayTitleHider : MelonMod
    {
        private const string ModCategory = "CustomConsoleTitle";
        private const string CustomTitleText = "TitleText";
        private string TitleString;

        public override void OnApplicationStart() // Runs after Game Initialization.
        {
            ModPrefs.RegisterCategory(ModCategory, "Custom Console Title");

            ModPrefs.RegisterPrefString(ModCategory, CustomTitleText, "Being a Cutie!", "Custom Console Text");

            TitleString = ModPrefs.GetString(ModCategory, CustomTitleText);

            Console.Title = string.Format(TitleString);
        }

        public override void OnModSettingsApplied()
        {
            // Highly recommend using UIExpansionKit to easily change your title (For VRChat)

            TitleString = ModPrefs.GetString(ModCategory, CustomTitleText);

            Console.Title = string.Format(TitleString);
            MelonModLogger.Log("Set console title to: " + TitleString);
        }
    }
}
