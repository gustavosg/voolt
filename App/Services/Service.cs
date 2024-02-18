using Domain;
using Repository;
using System.Text.Json;

namespace Services
{
    public class Service : IService
    {
        private readonly IRepository webSiteHeaderRepository;

        public Service(
            IRepository webSiteHeaderRepository
            )
        {
            this.webSiteHeaderRepository = webSiteHeaderRepository;

        }
        public Object Get(string key)
        {
            return (JsonSerializer.Serialize(webSiteHeaderRepository.Get(key)));
        }

        public Content GetAll()
        => webSiteHeaderRepository.GetAll();


        public void Add()
            => webSiteHeaderRepository.Add();
        
        public Object Edit(string key, string section, Object model)
            => webSiteHeaderRepository.Edit(key, section, System.Text.Json.JsonSerializer.Serialize(model));
    }
}
