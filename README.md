# ServerObjectCreator

![ServerObjectCreator](https://img.shields.io/badge/Version-1.0-blue.svg) ![License](https://img.shields.io/badge/License-MIT-green.svg)

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

---

## 🛠 Installation & Setup

### 1️⃣ **Clone the Repository**
```sh
git clone https://github.com/your-username/ServerObjectCreator.git
cd ServerObjectCreator
```

### 2️⃣ **Build the Project**
- Open the solution in **Visual Studio** or run:
```sh
dotnet build
```

### 3️⃣ **Run the Program**
```sh
dotnet run
```

---

## 📖 Usage Guide

### 🏠 **Main Menu**
When launched, the program presents a **menu-driven interface**:

```
╔════════════════════════════════════════════════════╗
║         ServerObjects File Utility (v1.0)         ║
╠════════════════════════════════════════════════════╣
║  This tool helps manage 'serverobjects.lua' files  ║
║  for SWGEmu custom_scripts folder structure.       ║
╚════════════════════════════════════════════════════╝

Current Paths:
  - Custom Scripts: C:\Projects\custom_scripts
  - Scripts:        C:\Projects\scripts

Available Actions:
[1] Create 'serverobjects.lua'
[2] Fix Child Folder References
[3] Fix File Includes
[4] Delete All 'serverobjects.lua' (⚠️ Use with caution)
[5] Set Custom/Scripts Paths
[6] Replicate Folder Structure
[0] Exit
```

### 🔹 **Options Explained**
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

The program stores its settings in `config.json`:

```json
{
  "CustomScriptsPath": "C:\SWG\custom_scripts",
  "ScriptsPath": "C:\SWG\scripts"
}
```

To update the paths manually:
- Edit `config.json` OR
- Use **option `[5] Set Paths`** in the menu

---

## 🏗 Project Structure

```
ServerObjectCreator/
│── ServerObjectCreator.sln          # Solution file
│── README.md                        # This documentation
│── config.json                       # Stores paths
│── Program.cs                        # Main execution flow
│
├── managers/                         # Handles core logic
│   │── ConfigManager.cs               # Manages settings and paths
│   │── FileManager.cs                 # Handles file operations
│   │── MenuUI.cs                      # Displays the UI
│
├── obj/                               # Build output
├── bin/                               # Executable output
```

---

## 🤝 Contributing

💡 **Want to improve this project?** Feel free to contribute!

1. **Fork the repository**  
2. **Create a feature branch** (`git checkout -b new-feature`)  
3. **Commit changes** (`git commit -m "Added a new feature"`)  
4. **Push to the branch** (`git push origin new-feature`)  
5. **Submit a pull request**  

---

## 📝 License

This project is licensed under the **MIT License**.

```
MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
...
```

---

## 🎯 Future Improvements (TODO List)
- [ ] Add **logging to a file** instead of just console output
- [ ] Add **unit tests** to validate functions
- [ ] Add **CLI arguments** (e.g., `--fix`, `--delete-all`)
- [ ] Support **custom exclusions** for folder replication

---

## 🛠 Need Help?
If you run into issues, open an [issue on GitHub](https://github.com/your-username/ServerObjectCreator/issues) or reach out.

---

## ⭐ Like this project?
If you found this tool useful, **give it a star ⭐ on GitHub**!

```
git clone https://github.com/your-username/ServerObjectCreator.git
```
