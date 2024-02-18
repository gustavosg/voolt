
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
        Object Get(string sectionId, string key);
        Content GetAll();
        void Save(Content content);
        
        Content GetContent();
    }
}
