
using Domain;
using Newtonsoft.Json;

namespace Repository
{
    public class Repository : Core.Repository.Repository, IRepository
    {
        string textJsonFile = String.Empty;

        public Repository()
        {
            Prepare();
        }

        private void Prepare()
        {
            textJsonFile = base.GetJsonContent();

            if (String.IsNullOrWhiteSpace(textJsonFile))
            {
                Content content = new();
                textJsonFile = System.Text.Json.JsonSerializer.Serialize(content);

                base.Save(textJsonFile);
            }
        }

        public Content GetContent()
        {
            textJsonFile = base.GetJsonContent();

            return JsonConvert.DeserializeObject<Content>(textJsonFile);
        }

        public Object Get(string sectionId, string key)
        {
            Content content = GetContent();
            Object dataReturn = null;

            switch (sectionId.ToUpperInvariant())
            {
                case "WEBSITEHEADERS":
                    {
                        dataReturn = content.WebSiteHeaders.FirstOrDefault(x => x.Id.Equals(key));
                        break;
                    }
                case "WEBSITEHEROES":
                    {
                        dataReturn = content.WebSiteHeroes.FirstOrDefault(x => x.Id.Equals(key));
                        break;
                    }
                case "SERVICES":
                    {
                        dataReturn = content.Services.FirstOrDefault(x => x.Id.Equals(key));
                        break;
                    }
                default:
                    break;
            }

            if (dataReturn is null)
                throw new Exception("Not Found");

            return dataReturn;
        }

        public Content GetAll() => (GetContent());

        public void Save(Content content)
        {
            base.Save(JsonConvert.SerializeObject(content));
        }

    }
}
