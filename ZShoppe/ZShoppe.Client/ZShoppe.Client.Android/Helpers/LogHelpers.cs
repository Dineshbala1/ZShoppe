using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Serilog;
using Serilog.Events;

namespace ZShoppe.Client.Droid.Helpers
{
    public static class LogHelpers
    {
        public const string OutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message:lj} {Properties:j}{NewLine}{Exception}";

        public static async Task InitDefaultLogger()
        {
            var config = new LoggerConfiguration();
            var minimumLevel = LogEventLevel.Verbose;
            var context = global::Android.App.Application.Context;

            PackageManager manager = context.PackageManager;
            PackageInfo info = manager.GetPackageInfo(context.PackageName, 0);

            var version = info.VersionName;

            try
            {
                var logsFolder = new Java.IO.File(Application.Context.GetExternalCacheDirs().First(), "logs");
                if (!logsFolder.Exists())
                {
                    logsFolder.Mkdirs();
                }

                var machineName = Android.OS.Build.Model;

                // test file creation
                var versionFile = new Java.IO.File(Path.Combine(logsFolder.AbsolutePath,
                    $"{Application.Context.PackageName}_{version}_{machineName}"));
                versionFile.CreateNewFile();
                versionFile.Delete();

                var logFile = Path.Combine(logsFolder.AbsolutePath,
                    $"{Application.Context.PackageName}_{version}_{machineName}_.txt");
                config.WriteTo.File(
                    logFile,
                    outputTemplate: OutputTemplate,
                    restrictedToMinimumLevel: minimumLevel, flushToDiskInterval: new TimeSpan(24, 0, 0, 0));
            }
            catch (Exception)
            {
                // something went wrong with the log file creation.. maybe no access
            }

            config.WriteTo.AndroidLog();
            config.MinimumLevel.Verbose();

#if DEBUG
            config.WriteTo.Debug(outputTemplate: OutputTemplate);
#endif

            Log.Logger = config.CreateLogger();
            Log.Verbose("App {PackageName} is starting {Version}", Application.Context.PackageName, version);

            await Task.FromResult(1);
        }
    }
}