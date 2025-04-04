﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServerObjectCreator.managers
{
    public static class FileManager
    {
        public static void CreateServerObjectFiles()
        {
            if (!ConfigManager.ValidateCustomScriptsPath()) return;

            foreach (var dir in Directory.GetDirectories(ConfigManager.Config.CustomScriptsPath, "*", SearchOption.AllDirectories))
            {
                string luaFile = Path.Combine(dir, "serverobjects.lua");
                if (!File.Exists(luaFile))
                {
                    string folderName = new DirectoryInfo(dir).Name;
                    string content = GenerateServerObjectsFile(folderName, Enumerable.Empty<string>(), Enumerable.Empty<string>());
                    File.WriteAllText(luaFile, content);
                    Console.WriteLine($"Created: {luaFile}");
                }
                else
                {
                    Console.WriteLine($"Skipped (already exists): {luaFile}");
                }
            }

            Console.WriteLine("\nAll done!");
        }

        public static void DeleteAllServerObjectFiles()
        {
            if (!ConfigManager.ValidateCustomScriptsPath()) return;

            var files = Directory.GetFiles(ConfigManager.Config.CustomScriptsPath, "serverobjects.lua", SearchOption.AllDirectories);
            int deleted = 0;

            foreach (var file in files)
            {
                try
                {
                    File.Delete(file);
                    Console.WriteLine($"Deleted: {file}");
                    deleted++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to delete {file}: {ex.Message}");
                }
            }

            Console.WriteLine($"\nDeleted {deleted} serverobjects.lua files.");
        }

        public static void FixChildFolderIncludes()
        {
            if (!ConfigManager.ValidateCustomScriptsPath()) return;

            Console.WriteLine("Scanning and fixing child folder references...\n");

            foreach (string dir in Directory.GetDirectories(ConfigManager.Config.CustomScriptsPath, "*", SearchOption.AllDirectories))
            {
                string parentFile = Path.Combine(dir, "serverobjects.lua");
                if (!File.Exists(parentFile)) continue;

                string folderName = new DirectoryInfo(dir).Name;

                var childDirs = Directory.GetDirectories(dir)
                    .Where(sub => File.Exists(Path.Combine(sub, "serverobjects.lua")))
                    .Select(sub => $"includeFile(\"../custom_scripts/{folderName}/{new DirectoryInfo(sub).Name}/serverobjects.lua\")");

                string content = File.ReadAllText(parentFile);
                var fileIncludes = ExtractIncludeBlock(content, "-- Server Objects", null);

                string newContent = GenerateServerObjectsFile(folderName, childDirs, fileIncludes);
                File.WriteAllText(parentFile, newContent);
                Console.WriteLine($"Updated: {parentFile}");
            }

            Console.WriteLine("\nChild folder references updated.");
        }

        public static void FixFileIncludes()
        {
            if (!ConfigManager.ValidateCustomScriptsPath()) return;

            Console.WriteLine("Scanning and fixing file includes...\n");

            foreach (string dir in Directory.GetDirectories(ConfigManager.Config.CustomScriptsPath, "*", SearchOption.AllDirectories))
            {
                string parentFile = Path.Combine(dir, "serverobjects.lua");
                if (!File.Exists(parentFile)) continue;

                string folderName = new DirectoryInfo(dir).Name;

                var files = Directory.GetFiles(dir, "*.lua")
                    .Where(f => !f.EndsWith("serverobjects.lua") && !f.EndsWith("objects.lua"))
                    .Select(f => $"includeFile(\"{Path.GetFileName(f)}\")");

                string content = File.ReadAllText(parentFile);
                var childIncludes = ExtractIncludeBlock(content, "--Children folder includes", "-- Server Objects");

                string newContent = GenerateServerObjectsFile(folderName, childIncludes, files);
                File.WriteAllText(parentFile, newContent);
                Console.WriteLine($"Updated: {parentFile}");
            }

            Console.WriteLine("\nFile includes updated.");
        }

        public static void ReplicateScriptFolderStructure()
        {
            if (!ConfigManager.ValidateScriptsPath() || !ConfigManager.ValidateCustomScriptsPath()) return;

            Console.WriteLine("Replicating folder structure...\n");

            string sourceRoot = Path.GetFullPath(ConfigManager.Config.ScriptsPath) + Path.DirectorySeparatorChar;
            string targetRoot = Path.GetFullPath(ConfigManager.Config.CustomScriptsPath) + Path.DirectorySeparatorChar;

            foreach (string dir in Directory.GetDirectories(sourceRoot, "*", SearchOption.AllDirectories))
            {
                if (dir.StartsWith(targetRoot, StringComparison.OrdinalIgnoreCase) || dir.Contains("custom_scripts"))
                {
                    Console.WriteLine($"Skipping: {dir} (avoiding self-cloning)");
                    continue;
                }

                string relative = dir.Substring(sourceRoot.Length);
                string targetDir = Path.Combine(ConfigManager.Config.CustomScriptsPath, relative);

                Directory.CreateDirectory(targetDir);
                Console.WriteLine($"Created: {targetDir}");
            }

            Console.WriteLine("\nFolder structure replicated.");
        }

        private static IEnumerable<string> ExtractIncludeBlock(string content, string startHeader, string? endHeader)
        {
            int start = content.IndexOf(startHeader);
            int end = endHeader != null ? content.IndexOf(endHeader, start + 1) : content.Length;

            if (start == -1 || end == -1 || start >= end) return Enumerable.Empty<string>();

            return content.Substring(start, end - start)
                .Split('\n')
                .Select(line => line.Trim())
                .Where(line => line.StartsWith("includeFile("));
        }

        private static string GenerateServerObjectsFile(string folderName, IEnumerable<string> childIncludes, IEnumerable<string> fileIncludes)
        {
            var childBlock = childIncludes.Any()
                ? string.Join("\n", childIncludes)
                : "-- (none)";

            var fileBlock = fileIncludes.Any()
                ? string.Join("\n", fileIncludes)
                : "-- (none)";

            return $@"--print(""\nCustom Server Objects ({folderName}) Loading...\n"")
--SR2 ServerObjects custom_script overrides
--Children folder includes:
{childBlock}

-- Server Objects includes:
{fileBlock}
";
        }
    }
}
