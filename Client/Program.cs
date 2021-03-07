using System;
using System.IO;
using CommandLine;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CommandOptions>(args)
                .WithParsed(StartWatching)
                .WithNotParsed(x => { Environment.Exit(1); });

            Console.ReadLine();
        }

        private static void StartWatching(CommandOptions options)
        {
            Console.WriteLine("Watching has started");
            options.SourceDirectoryPath = string.IsNullOrWhiteSpace(options.SourceDirectoryPath) ? Directory.GetCurrentDirectory():options.SourceDirectoryPath;
            WatchFile(options);
        }
        public static void WatchFile(CommandOptions options)
        {
            IFileCopier copier = new FileCopier();
            ILogger logger = new ConsoleLogger();
            IFileWatcher watcher = new FileWatcher(copier,logger);
            watcher.Watch(options);
        }



        

    }
}
