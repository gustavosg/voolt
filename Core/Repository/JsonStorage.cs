using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class JsonStorage
    {
        private string jsonPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\Data\\File.json";

        private void CheckFileExists()
        {
            if (!File.Exists(jsonPath))
                File.Create(jsonPath);
        }

        public async Task<string> Read()
        {
            CheckFileExists();

            return await File.ReadAllTextAsync(jsonPath);
        }

        public async Task Save(string content)
        {
            CheckFileExists();

            await File.WriteAllTextAsync(jsonPath, content);
        }
    }
}
