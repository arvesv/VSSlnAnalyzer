using System.CommandLine;


var fileOption = new Option<FileInfo?>(
    name: "--file",
    description: "The solution file to analyze");

var rootCommand =
    new RootCommand(
        "A tool that analyzes a Visual Studio SLN file and reports any project references in the SLN file that references outside of the SLN file.");
 rootCommand.AddOption(fileOption);

rootCommand.SetHandler((file) => { Core.SolutionFileTools.Analyze(file!); }, fileOption);

rootCommand.Invoke(args);

