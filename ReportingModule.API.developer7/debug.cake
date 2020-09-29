// To get nuget to work use ~\packages\nuget.CommandLine\tools\nuget.exe sources Update -Name TeamCity -UserName marcus -Password xxxxxxxx
// Repeat for nuget source DeepThought
// This changes your %AppData%\nuget\NuGet.config (and encrypts your password!)
#tool "nuget:?package=NUnit.ConsoleRunner"
#addin "Cake.Powershell"
#addin nuget:?package=Cake.Npm & prerelease
#addin "Cake.Gulp"

var target = Argument ("target", "Default");
string configuration = Argument ("configuration", "Debug");

var vsSolution = File ("ReportingModule.KingLivingInterface.sln");
var unitTestAssembly = File("../output/debug/ReportingModule.KingLivingInterface.Tests.dll");

Task ("BuildDebug")
  .IsDependentOn("Restore-Paket")
  .IsDependentOn("Build-Vs-Solution")
  .IsDependentOn("Run-Tests");

Task ("Restore-Paket")
  .Does (() => {
    Information ("Restoring Paket");
    StartPowershellFile ("../BuildTools/cake/restore-paket.ps1", _ => { });
  });

Task ("Build-Vs-Solution")
  .Does (() => {
    BuildSolution (vsSolution, configuration);
  });

void BuildSolution (Cake.Common.IO.Paths.ConvertableFilePath solution, string config) {
  var version = EnvironmentVariable ("BUILD_NUMBER") ?? "1.0.0.0";

  Information ("Building VS Solution: " + solution);
  NuGetRestore (solution);

  MSBuild (solution, settings => settings
    .WithTarget ("Build")
    .SetMaxCpuCount (0)
    .WithProperty ("RestorePackages", "false")
    .WithProperty ("DownloadPaket", "false")
    .WithProperty ("nr", "false")
    .SetConfiguration (config));
}

Task ("Run-Tests")
  .Does (() => {
    Information ("Running Unit Tests");
    NUnit3(unitTestAssembly);
  });

Task ("Default")
  .IsDependentOn ("BuildDebug");

RunTarget (target);