using ServerObjectCreator.models;
using System;

namespace ServerObjectCreator.managers
{
    public static class MenuUI
    {
        public static void SetupConsole()
        {
            // Set window size (Adjust values to match your preference)
            int width = 130; // Adjust width as needed
            int height = 50; // Adjust height as needed

            try
            {
                if (OperatingSystem.IsWindows())
                {
                    Console.SetWindowSize(width, height);
                    Console.SetBufferSize(width, height);
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not resize console - {ex.Message}");
            }
        }

        public static void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            string title = "ServerObjects File Utility (v1.0)";
            string description = "This tool helps manage 'serverobjects.lua' files for SWGEmu custom_scripts folder structure.";

            PrintCentered(title, ConsoleColor.Yellow, true);
            PrintCentered(description, ConsoleColor.DarkYellow, false);

            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowPaths(Config config)
        {
            Console.WriteLine("Current Paths:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  - Custom Scripts: {config.CustomScriptsPath}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"  - Scripts:        {config.ScriptsPath}");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Available Actions:");
            Console.ResetColor();

            WriteOption("1", "Create 'serverobjects.lua'", "Creates an empty 'serverobjects.lua' in each folder under custom_scripts (skips existing ones).");
            WriteOption("2", "Fix Child Folder References", "Adds includes for subfolder 'serverobjects.lua' files under the --Children folder includes section.");
            WriteOption("3", "Fix File Includes", "Adds includeFile lines for each Lua file (excluding serverobjects.lua & objects.lua) under -- Server Objects.");
            WriteOption("4", "Delete All 'serverobjects.lua'", "Deletes every 'serverobjects.lua' file under custom_scripts. ⚠️ Use with caution.");
            WriteOption("5", "Set Custom/Scripts Paths", "Update the paths for 'custom_scripts' and 'scripts' folders.");
            WriteOption("6", "Replicate Folder Structure", "Copies directory structure from 'scripts' to 'custom_scripts' (folders only).");
            WriteOption("0", "Exit", "Close this tool.");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
        }

        private static void WriteOption(string key, string title, string description)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{key}] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(title);
            Console.ResetColor();
            Console.WriteLine($"    {description}\n");
        }

        private static void PrintCentered(string text, ConsoleColor color, bool addBorder)
        {
            Console.ForegroundColor = color;
            int screenWidth = Console.WindowWidth;
            int padding = (screenWidth - text.Length) / 2;

            if (addBorder)
            {
                string border = new string('═', text.Length + 4);
                Console.WriteLine(new string(' ', padding) + $"╔{border}╗");
                Console.WriteLine(new string(' ', padding) + $"║  {text}  ║");
                Console.WriteLine(new string(' ', padding) + $"╚{border}╝");
            }
            else
            {
                Console.WriteLine(new string(' ', padding) + text);
            }

            Console.ResetColor();
        }
    }
}
