# ServerObjectCreator

![ServerObjectCreator](https://img.shields.io/badge/Version-1.0-blue.svg) ![License](https://img.shields.io/badge/License-AGPLv3-red.svg)

**ServerObjectCreator** is a C# utility designed to manage `serverobjects.lua` files within the `custom_scripts` directory for SWGEmu projects. It automates file creation, structure replication, reference corrections, and now supports all-in-one update features.

## 🚀 Features

- ✅ **Create** `serverobjects.lua` in all folders under `custom_scripts`
- ✅ **Fix child folder references** for subdirectory `serverobjects.lua` includes
- ✅ **Fix file includes** with `includeFile()` for each `.lua` file (excluding system files)
- ✅ **Delete all** `serverobjects.lua` files (⚠️ Use with caution)
- ✅ **Replicate folder structure** from `scripts` to `custom_scripts`
- ✅ **Generate `allobjects.lua`** from every `objects.lua` found recursively
- ✅ **All-in-one update** mode to run `[2]`, `[3]`, and `[7]` in one step
- ✅ **JSON-based config system** to persist custom/scripts paths
- ✅ **Cross-platform builds** for Windows and Linux (tested on Debian 12)
- ✅ **Supports CLI and Menu UI**

---

## 🛠 Installation & Setup

```bash
git clone https://github.com/MalaceNathrack/ServerObjectsManager.git
cd ServerObjectsManager
dotnet build
dotnet run
```

To create a Linux binary:
```bash
dotnet publish -c Release -r linux-x64 --self-contained true -o ./publish
```

---

## 📖 Usage Guide

### 🧾 Menu Options

```
[1] Create 'serverobjects.lua'
[2] Fix Child Folder References
[3] Fix File Includes
[4] Delete All 'serverobjects.lua'
[5] Set Custom/Scripts Paths
[6] Replicate Folder Structure
[7] Generate allobjects.lua from objects.lua files
[8] Run full update (2, 3, 7)
[0] Exit
```

### 🔹 What They Do

| Option | Description |
|--------|-------------|
| 1 | Creates empty `serverobjects.lua` in each subfolder |
| 2 | Adds includes for subfolder `serverobjects.lua` files |
| 3 | Adds `includeFile()` lines for all `.lua` files |
| 4 | Deletes all `serverobjects.lua` recursively |
| 5 | Set custom and scripts paths (stored in `config.json`) |
| 6 | Replicate `scripts` folder structure into `custom_scripts` |
| 7 | Scan for all `objects.lua` files and generate a categorized `allobjects.lua` |
| 8 | 📦 **NEW**: Runs `[2] Fix Child Includes`, `[3] Fix File Includes`, and `[7] Generate allobjects.lua` in order |
| 0 | Exit the tool |

---

## ⚙ CLI Options

Run with:
```bash
dotnet run -- --fix-children
dotnet run -- --fix-files
dotnet run -- --generate-allobjects
dotnet run -- --update-all
```

| Argument              | Description                                                  |
|-----------------------|--------------------------------------------------------------|
| `--create`            | Create `serverobjects.lua` in subfolders                     |
| `--fix-children`      | Fix child folder includes                                    |
| `--fix-files`         | Fix file includes (`*.lua`)                                  |
| `--delete`            | Delete all `serverobjects.lua`                               |
| `--replicate`         | Copy folder structure from `scripts` to `custom_scripts`     |
| `--generate-allobjects` | Generate `allobjects.lua` listing all `objects.lua` files   |
| `--update-all`        | 📦 **NEW**: Runs all update steps together (2, 3, 7)          |
| `--set-paths`         | Prompt to enter paths                                        |
| `--help`              | Show help message                                            |

---

## 📦 Output Example for allobjects.lua

```lua
-- Automatically generated list of all objects.lua files
-- Grouped by folder

-- creatures/npc
includeFile("custom_scripts/creatures/npc/objects.lua")

-- creatures/player
includeFile("custom_scripts/creatures/player/objects.lua")
```

---

## 📂 Config Format

Stored as `config.json` in root:

```json
{
  "CustomScriptsPath": "C:\Path\to\custom_scripts",
  "ScriptsPath": "C:\Path\to\scripts"
}
```

---

## 📝 License

This project is licensed under the **GNU Affero General Public License v3.0 (AGPLv3)**.

---

## ⭐ Like this project?

If this helped you with your SWGEmu modding, give it a ⭐ star on GitHub!

```
https://github.com/MalaceNathrack/ServerObjectsManager
```
