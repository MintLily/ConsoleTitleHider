using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(XSOverlayTitleHider.BuildInfo.Name)]
[assembly: AssemblyDescription(XSOverlayTitleHider.BuildInfo.Description)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(XSOverlayTitleHider.BuildInfo.Company)]
[assembly: AssemblyProduct(XSOverlayTitleHider.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + XSOverlayTitleHider.BuildInfo.Author)]
[assembly: AssemblyTrademark(XSOverlayTitleHider.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(XSOverlayTitleHider.BuildInfo.Version)]
[assembly: AssemblyFileVersion(XSOverlayTitleHider.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(XSOverlayTitleHider.XSOverlayTitleHider), XSOverlayTitleHider.BuildInfo.Name, XSOverlayTitleHider.BuildInfo.Version, XSOverlayTitleHider.BuildInfo.Author, XSOverlayTitleHider.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame("VRChat", "VRChat")]