
using Core.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository : Core.Repository.IRepository
    {
        Object Get(string key);
        Content GetAll();
        void Add();
        object Edit(string key, string section, string contentToSave);
    }
}
