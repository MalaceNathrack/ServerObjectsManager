using ServerObjectCreator.models;
using System;
using System.IO;
using System.Text.Json;

namespace ServerObjectCreator.managers
{
    public static class ConfigManager
    {
        private const string ConfigFilePath = "config.json";
        public static Config Config { get; private set; } = new Config();

        /// <summary> Loads saved paths or prompts user to set them. </summary>
        public static void LoadPaths()
        {
            if (File.Exists(ConfigFilePath))
            {
                try
                {
                    string? json = File.ReadAllText(ConfigFilePath);
                    if (json is not null)
                    {
                        Config = JsonSerializer.Deserialize<Config>(json) ?? new Config();
                    }
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load config: {ex.Message}");
                }
            }

            Console.WriteLine("Configuration not found or invalid. Please set the paths.");
            SetPaths();
        }

        /// <summary> Prompts user for paths and saves them to config. </summary>
        public static void SetPaths()
        {
            Console.Write("Enter the path to the custom_scripts folder: ");
            Config.CustomScriptsPath = Console.ReadLine()?.Trim() ?? string.Empty;

            Console.Write("Enter the path to the scripts folder: ");
            Config.ScriptsPath = Console.ReadLine()?.Trim() ?? string.Empty;

            SavePaths();
            Console.WriteLine("Paths saved successfully!");
        }

        /// <summary> Saves the current config to config.json </summary>
        private static void SavePaths()
        {
            try
            {
                string json = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to save config: {ex.Message}");
            }
        }

        /// <summary> Allows setting paths directly from CLI args. </summary>
        public static void SetPathsFromArgs(string customPath, string scriptsPath)
        {
            Config.CustomScriptsPath = customPath.Trim();
            Config.ScriptsPath = scriptsPath.Trim();
            SavePaths();
            Console.WriteLine("✅ Paths set via CLI.");
        }

        /// <summary> Verifies if the custom_scripts path exists. </summary>
        public static bool ValidateCustomScriptsPath()
        {
            if (!Directory.Exists(Config.CustomScriptsPath))
            {
                Console.WriteLine("❌ The custom_scripts path does not exist. Run '--set-paths' first.");
                return false;
            }
            return true;
        }

        /// <summary> Verifies if the scripts path exists. </summary>
        public static bool ValidateScriptsPath()
        {
            if (!Directory.Exists(Config.ScriptsPath))
            {
                Console.WriteLine("❌ The scripts path does not exist. Run '--set-paths' first.");
                return false;
            }
            return true;
        }

        /// <summary> Validates that both custom_scripts and scripts paths are set and exist. </summary>
        public static bool ValidateAllPaths()
        {
            return ValidateCustomScriptsPath() && ValidateScriptsPath();
        }
    }
}
