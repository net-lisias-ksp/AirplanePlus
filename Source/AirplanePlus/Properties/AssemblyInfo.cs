using System.Reflection;
using System.Runtime.CompilerServices;

// Information about this assembly is defined by the following attributes. 
// Change them to the values specific to your project.

[assembly: AssemblyTitle("Airplane+")]
[assembly: AssemblyDescription("Powerful stockalike parts for aircraft enthusiasts.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(AirplanePlus.LegalMamboJambo.Company)]
[assembly: AssemblyProduct(AirplanePlus.LegalMamboJambo.Product)]
[assembly: AssemblyCopyright(AirplanePlus.LegalMamboJambo.Copyright)]
[assembly: AssemblyTrademark(AirplanePlus.LegalMamboJambo.Trademark)]
[assembly: AssemblyCulture("")]

// The assembly version has the format "{Major}.{Minor}.{Build}.{Revision}".
// The form "{Major}.{Minor}.*" will automatically update the build and revision,
// and "{Major}.{Minor}.{Build}.*" will update just the revision.

[assembly: AssemblyVersion(AirplanePlus.Version.Number)]
[assembly: AssemblyFileVersion(AirplanePlus.Version.Number)]
[assembly: KSPAssembly("AirplanePlus", AirplanePlus.Version.major, AirplanePlus.Version.minor)]
#if KSPE
[assembly: KSPAssemblyDependency("KSPe", 2, 5)]
[assembly: KSPAssemblyDependency("KSPe.UI", 2, 5)]
#else
[assembly: KSPAssemblyDependency("KSPe.Light.APP", 2, 5)]
#endif