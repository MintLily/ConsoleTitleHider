using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(ConsoleTitleHider.BuildInfo.Name)]
[assembly: AssemblyDescription(ConsoleTitleHider.BuildInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(ConsoleTitleHider.BuildInfo.Company)]
[assembly: AssemblyProduct(ConsoleTitleHider.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + ConsoleTitleHider.BuildInfo.Author)]
[assembly: AssemblyTrademark(ConsoleTitleHider.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(ConsoleTitleHider.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ConsoleTitleHider.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonInfo(typeof(ConsoleTitleHider.Main), ConsoleTitleHider.BuildInfo.Name, ConsoleTitleHider.BuildInfo.Version, ConsoleTitleHider.BuildInfo.Author, ConsoleTitleHider.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame]