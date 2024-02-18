using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class JsonStorage
    {
        string jsonPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\File.json";

        public string Read()
        {
            return File.ReadAllText(jsonPath);
        }

        public void Save(string content)
        {
            File.WriteAllText(jsonPath, content);
        }
    }
}
