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
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
        public const string Description = "Applies a title change for the MelonLoader Console Window, hiding it from XSOverlay.";
    }

    public class XSOverlayTitleHider : MelonMod
    {
        public override void OnApplicationStart() // Runs after Game Initialization.
        {
            Console.Title = string.Format("VRChat");
        }
    }
}