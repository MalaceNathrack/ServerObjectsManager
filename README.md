# ServerObjectCreator

![ServerObjectCreator](https://img.shields.io/badge/Version-1.0-blue.svg) ![License](https://img.shields.io/badge/License-AGPLv3-red.svg)

**ServerObjectCreator** is a C# utility designed to manage `serverobjects.lua` files within the `custom_scripts` directory for SWGEmu projects. It automates file creation, structure replication, and reference corrections.

## 🚀 Features

- ✅ **Create** `serverobjects.lua` in all folders under `custom_scripts`
- ✅ **Fix child folder references** to ensure all subfolders are properly included
- ✅ **Fix file includes** by adding `includeFile()` lines for `.lua` scripts
- ✅ **Delete all** `serverobjects.lua` files (⚠️ Use with caution)
- ✅ **Replicate folder structure** from `scripts` to `custom_scripts`
- ✅ **JSON-based configuration** to persist paths
- ✅ **Prevents recursive duplication** of `custom_scripts`
- ✅ **Clean and structured menu UI**
- ✅ **Command-line mode and interactive menu**

---

## 🔧 Building the Project (Windows & Linux)

### 🖥️ Windows

1. **Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)**  
2. **Clone the repo:**
   ```bash
   git clone https://github.com/MalaceNathrack/ServerObjectCreator.git
   cd ServerObjectCreator
   ```
3. **Build and run the app:**
   ```bash
   dotnet build
   dotnet run
   ```

Or open `ServerObjectCreator.sln` in **Visual Studio 2022+** and press **F5** to run.

---

### 🐧 Linux (Debian/Ubuntu)

1. **Install .NET 8 SDK:**
   ```bash
   sudo apt update
   sudo apt install -y dotnet-sdk-8.0
   ```

2. **Clone the repo and run:**
   ```bash
   git clone https://github.com/MalaceNathrack/ServerObjectCreator.git
   cd ServerObjectCreator
   dotnet build
   dotnet run
   ```

---

## 🖥 CLI Mode vs Interactive Menu

You can use the app with **command-line arguments** for automation, or without args to launch the menu UI.

### ✅ Command-line Examples

```bash
# Create 'serverobjects.lua' in all folders (requires valid config)
dotnet run -- --create

# Fix includeFile() references for Lua files
dotnet run -- --fix-files

# Fix child folder include references
dotnet run -- --fix-children

# Delete all serverobjects.lua files (⚠️ use with caution)
dotnet run -- --delete

# Replicate folder structure from 'scripts' to 'custom_scripts'
dotnet run -- --replicate

# Set paths interactively
dotnet run -- --set-paths

# Set paths from CLI arguments
dotnet run -- --set-paths "C:/MyGame/custom_scripts" "C:/MyGame/scripts"

# Show help
dotnet run -- --help
```

If the paths are not set or invalid, a friendly message will prompt you to use `--set-paths` first.

---

## 📖 Usage Guide

```
╔════════════════════════════════════════════════════╗
║         ServerObjects File Utility (v1.0)         ║
╠════════════════════════════════════════════════════╣
║  This tool helps manage 'serverobjects.lua' files  ║
║  for SWGEmu custom_scripts folder structure.       ║
╚════════════════════════════════════════════════════╝
```

### Menu Actions

| Option | Description |
|--------|-------------|
| **1. Create 'serverobjects.lua'** | Generates `serverobjects.lua` in all subdirectories (if missing). |
| **2. Fix Child Folder References** | Ensures subfolder `serverobjects.lua` files are correctly included. |
| **3. Fix File Includes** | Adds `includeFile()` lines for all `.lua` scripts inside the directory. |
| **4. Delete All 'serverobjects.lua'** | ⚠️ Permanently removes every `serverobjects.lua` inside `custom_scripts`. |
| **5. Set Custom/Scripts Paths** | Allows setting or updating `custom_scripts` and `scripts` paths. |
| **6. Replicate Folder Structure** | Copies the structure of `scripts` into `custom_scripts` (excluding `custom_scripts` itself). |
| **0. Exit** | Closes the tool. |

---

## ⚙ Configuration (`config.json`)

Stores custom paths:

```json
{
  "CustomScriptsPath": "C:\SWG\custom_scripts",
  "ScriptsPath": "C:\SWG\scripts"
}
```

Can be edited manually, or via:
```bash
dotnet run -- --set-paths "path/to/custom_scripts" "path/to/scripts"
```

---

## 🏗 Project Structure

```
ServerObjectCreator/
│── ServerObjectCreator.sln          # Solution file
│── README.md                        # This documentation
│── config.json                      # Stores paths
│── Program.cs                       # Main entry point
│
├── managers/                        # Handles core logic
│   ├── ConfigManager.cs
│   ├── FileManager.cs
│   └── MenuUI.cs
├── obj/                             # Build artifacts
├── bin/                             # Executables
```

---

## 🤝 Contributing

💡 **Want to improve this project?** Feel free to contribute!

1. Fork the repo  
2. Create a branch (`git checkout -b feature-name`)  
3. Make changes and commit  
4. Push and open a Pull Request

---

## 📝 License

This project is licensed under the **GNU Affero General Public License v3.0 (AGPLv3)**.  
See [LICENSE.txt](LICENSE.txt) or visit [gnu.org/licenses/agpl-3.0](https://www.gnu.org/licenses/agpl-3.0.html).

---

## ⭐ Like this project?

Give it a ⭐ on GitHub or share it with other SWGEmu developers!
