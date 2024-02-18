using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        private JsonStorage storage { get; set; }

        public Repository()
        {
            storage = new JsonStorage();
        }

        public async Task<string> Get()
        {
            return await storage.Read();
        }

        public async Task Save(string content)
        {
            await storage.Save(content);
        }
    }
}
