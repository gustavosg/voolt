using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IService
    {
        Object Get(string key);
        Content GetAll();
        void Add();
        Object Edit(string key, string section, Object model);
    }
}
