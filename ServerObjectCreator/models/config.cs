using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ServerObjectCreator.models
{
    public class Config
    {
        public string CustomScriptsPath { get; set; } = string.Empty;
        public string ScriptsPath { get; set; } = string.Empty;
    }

}
