// To get nuget to work use ~\packages\nuget.CommandLine\tools\nuget.exe sources Update -Name TeamCity -UserName marcus -Password xxxxxxxx
// Repeat for nuget source DeepThought
// This changes your %AppData%\nuget\NuGet.config (and encrypts your password!)
#addin "Cake.Powershell"
#addin nuget:?package=Cake.Yarn
#addin "Cake.Gulp"

var target = Argument("target", "Default");
string configuration = Argument("configuration", "Release");

var vsSolutions = new [] {
  File("ReportingModule.KingLivingInterface.sln")
};

Task("BuildRelease")
  .IsDependentOn("Restore-Paket")
  .IsDependentOn("Build-Vs-Solutions")
  .Does(() =>
{
});

Task("Restore-Paket")
  .Does(() => {
    Information("Restoring Paket");
    StartPowershellFile ("../BuildTools/cake/restore-paket.ps1", _ => { });
  });

Task("Build-Vs-Solutions")
	.Does(() =>
{
	BuildSolutions(vsSolutions, configuration);
});

void BuildSolutions(Cake.Common.IO.Paths.ConvertableFilePath[] solutions, string config)
{
  var version = EnvironmentVariable("BUILD_NUMBER") ?? "1.0.0.0";
  
  foreach (var sln in solutions)
  {
    Information("Building VS Solution: " + sln);
    NuGetRestore(sln);

    MSBuild(sln, settings => settings
      .WithTarget("Clean")
      .WithTarget("Build") 
      .SetMaxCpuCount(0)
      .WithProperty("RestorePackages", "false")
      .WithProperty("DownloadPaket", "false")
      .WithProperty("nr", "false")
      .WithProperty("RunOctoPack", "true")
      .SetConfiguration(config));
  }
}

Task("Default")
  .IsDependentOn("BuildRelease");

RunTarget(target);

