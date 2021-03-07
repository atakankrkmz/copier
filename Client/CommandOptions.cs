using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace Client
{
    public class CommandOptions
    {
        [Option('s',"sourceDirectoryPath",HelpText = "Parent directory where the files will be searched")]
        public string SourceDirectoryPath { get; set; }

        [Option('f',"fileGlobPattern", Required = true, HelpText = "Target files to be searched")]
        public string FileGlobPattern { get; set; }
        
        [Option('d', "destinationDirectoryPath", Required = true, HelpText = "Destination directory path to copy files which copier found")]
        public string DestinationDirectoryPath { get; set; }
        [Option('o',"overwriteTargetFiles",Default = false,Required = false,HelpText = "If passed true, copier will overwrite existing files at the target location")]
        public bool OverwriteTargetFiles { get; set; }
        [Option('v',"verbose",Default = false,Required = false,HelpText = "If passed true, copier will give you more information on console")]
        public bool Verbose { get; set; }

        [Usage]
        public static IEnumerable<Example> Examples => new List<Example>()
        {
            new Example("Starts the copier", new UnParserSettings() {PreferShortName = true}, new CommandOptions()
            {
                SourceDirectoryPath = "C:/Users/user/MyDocuments/Images",
                FileGlobPattern = "*.png",
                DestinationDirectoryPath = "C:/Users/user/MyDocuments/NewImages",
                OverwriteTargetFiles = true
            }),
            new Example("Starts the copier and overwrites the target files", new UnParserSettings() {PreferShortName = true}, new CommandOptions()
            {
                SourceDirectoryPath = "C:/Users/user/MyDocuments/Images",
                FileGlobPattern = "*.png",
                DestinationDirectoryPath = "C:/Users/user/MyDocuments/NewImages",
                OverwriteTargetFiles = true
            }),
            new Example("Starts the copier and overwrites the target files and outputs verbose messages", new UnParserSettings() {PreferShortName = true}, new CommandOptions()
            {
                SourceDirectoryPath = "C:/Users/user/MyDocuments/Images",
                FileGlobPattern = "*.png",
                DestinationDirectoryPath = "C:/Users/user/MyDocuments/NewImages",
                OverwriteTargetFiles = true,
                Verbose = true
            }),
        };
    }
}
