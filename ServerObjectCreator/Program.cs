using ServerObjectCreator.managers;
using ServerObjectCreator.UI;
using System;

class Program
{
    static void Main(string[] args)
    {
        MenuUI.SetupConsole();
        ConfigManager.LoadPaths();

        if (args.Length > 0)
        {
            HandleCommandLineArgs(args);
            return;
        }

        ShowInteractiveMenu();
    }

    static void HandleCommandLineArgs(string[] args)
    {
        string arg = args[0].ToLower();

        switch (arg)
        {
            case "--create":
                FileManager.CreateServerObjectFiles();
                break;
            case "--fix-children":
                FileManager.FixChildFolderIncludes();
                break;
            case "--fix-files":
                FileManager.FixFileIncludes();
                break;
            case "--delete":
                FileManager.DeleteAllServerObjectFiles();
                break;
            case "--replicate":
                FileManager.ReplicateScriptFolderStructure();
                break;
            case "--set-paths":
                ConfigManager.SetPaths();
                break;
            case "--help":
            default:
                ShowCommandHelp();
                break;
        }
    }

    static void ShowCommandHelp()
    {
        Console.WriteLine("Usage: dotnet ServerObjectCreator.dll [option]");
        Console.WriteLine();
        Console.WriteLine("Options:");
        Console.WriteLine("  --create        Create serverobjects.lua in all folders");
        Console.WriteLine("  --fix-children  Fix child folder includes");
        Console.WriteLine("  --fix-files     Fix includeFile() for Lua files");
        Console.WriteLine("  --delete        Delete all serverobjects.lua files");
        Console.WriteLine("  --replicate     Replicate scripts folder structure");
        Console.WriteLine("  --set-paths     Manually set config paths");
        Console.WriteLine("  --help          Show this help message");
    }

    static void ShowInteractiveMenu()
    {
        bool running = true;
        while (running)
        {
            MenuUI.ShowHeader();
            MenuUI.ShowPaths(ConfigManager.Config);
            MenuUI.ShowMenu();

            switch (Console.ReadLine())
            {
                case "1": FileManager.CreateServerObjectFiles(); break;
                case "2": FileManager.FixChildFolderIncludes(); break;
                case "3": FileManager.FixFileIncludes(); break;
                case "4": FileManager.DeleteAllServerObjectFiles(); break;
                case "5": ConfigManager.SetPaths(); break;
                case "6": FileManager.ReplicateScriptFolderStructure(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }

}
