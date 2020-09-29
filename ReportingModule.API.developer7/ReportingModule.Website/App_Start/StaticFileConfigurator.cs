using System.Configuration;
using Microsoft.Owin.Extensions;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace ReportingModule.Website
{
    public static class StaticFileConfigurator
    {
        public static void ConfigureStaticFiles(this IAppBuilder appBuilder)
        {
            if (!bool.TryParse(ConfigurationManager.AppSettings["EnableStaticFiles"], out var staticFilesEnabled)
                || !staticFilesEnabled) return;

            var physicalFileSystem = new PhysicalFileSystem("./www");
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = false,
                FileSystem = physicalFileSystem,
                StaticFileOptions =
                {
                    FileSystem = physicalFileSystem,
                    ServeUnknownFileTypes = true
                },
                DefaultFilesOptions =
                {
                    DefaultFileNames = new[]
                    {
                        "index.html"
                    }
                }
            };

            appBuilder.UseFileServer(options);
            appBuilder.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}