using ServerObjectCreator.managers;
using System;
using System.IO;

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
                if (!ConfigManager.ValidateAllPaths()) return;
                FileManager.CreateServerObjectFiles();
                break;

            case "--fix-children":
                if (!ConfigManager.ValidateAllPaths()) return;
                FileManager.FixChildFolderIncludes();
                break;

            case "--fix-files":
                if (!ConfigManager.ValidateAllPaths()) return;
                FileManager.FixFileIncludes();
                break;

            case "--delete":
                if (!ConfigManager.ValidateAllPaths()) return;
                FileManager.DeleteAllServerObjectFiles();
                break;

            case "--replicate":
                if (!ConfigManager.ValidateAllPaths()) return;
                FileManager.ReplicateScriptFolderStructure();
                break;

            case "--set-paths":
                if (args.Length >= 3)
                {
                    ConfigManager.SetPathsFromArgs(args[1], args[2]);
                }
                else
                {
                    ConfigManager.SetPaths(); // fallback to interactive
                }
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
        Console.WriteLine("  --create         Create serverobjects.lua in all folders");
        Console.WriteLine("  --fix-children   Fix child folder includes");
        Console.WriteLine("  --fix-files      Fix includeFile() for Lua files");
        Console.WriteLine("  --delete         Delete all serverobjects.lua files");
        Console.WriteLine("  --replicate      Replicate scripts folder structure");
        Console.WriteLine("  --set-paths      Interactively set config paths");
        Console.WriteLine("  --set-paths <custom> <scripts>   Set paths via CLI");
        Console.WriteLine("  --help           Show this help message");
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
                case "1": if (ConfigManager.ValidateAllPaths()) FileManager.CreateServerObjectFiles(); break;
                case "2": if (ConfigManager.ValidateAllPaths()) FileManager.FixChildFolderIncludes(); break;
                case "3": if (ConfigManager.ValidateAllPaths()) FileManager.FixFileIncludes(); break;
                case "4": if (ConfigManager.ValidateAllPaths()) FileManager.DeleteAllServerObjectFiles(); break;
                case "5": ConfigManager.SetPaths(); break;
                case "6": if (ConfigManager.ValidateAllPaths()) FileManager.ReplicateScriptFolderStructure(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid choice. Try again."); break;
            }
        }
    }
}
