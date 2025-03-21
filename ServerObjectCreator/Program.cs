using ServerObjectCreator.managers;
using ServerObjectCreator.UI;
using System;

class Program
{
    static void Main(string[] args)
    {
        MenuUI.SetupConsole();
        ConfigManager.LoadPaths(); // Load paths on startup

        bool running = true;

        while (running)
        {
            MenuUI.ShowHeader();
            MenuUI.ShowPaths(ConfigManager.Config);
            MenuUI.ShowMenu();

            switch (Console.ReadLine())
            {
                case "1":
                    FileManager.CreateServerObjectFiles();
                    break;
                case "2":
                    FileManager.FixChildFolderIncludes();
                    break;
                case "3":
                    FileManager.FixFileIncludes();
                    break;
                case "4":
                    FileManager.DeleteAllServerObjectFiles();
                    break;
                case "5":
                    ConfigManager.SetPaths();
                    break;
                case "6":
                    FileManager.ReplicateScriptFolderStructure();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
