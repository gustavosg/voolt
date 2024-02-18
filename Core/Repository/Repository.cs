using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class Repository : IRepository
    {
        private JsonStorage storage { get; set; }

        public Repository()
        {
            storage = new JsonStorage();
        }

        public string GetJsonContent()
        {
            return storage.Read();
        }

        public void Save(string content)
        {
            storage.Save(content);
        }
    }
}
