
using Domain;
using Newtonsoft.Json;
using System.Reflection;

namespace Repository
{
    public class Repository : Core.Repository.Repository, IRepository
    {
        string textJsonFile = String.Empty;

        public Repository() {
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

        private Content GetContent()
        {
            textJsonFile = base.GetJsonContent();

            Content content = JsonConvert.DeserializeObject<Content>(textJsonFile);

            return content;
        }


        public Object Get(string key)
        {
            Content content = GetContent();

            if (content.WebSiteHeaders.Any(x => !x.BusinessName.Equals(key)))
                throw new Exception("Not Found");

            return content.WebSiteHeaders.FirstOrDefault(x => x.BusinessName.Equals(key, StringComparison.Ordinal)) ?? null;
        }

        public Content GetAll() => (GetContent());

        public void Add()
        {
            Content content = new ();

            base.Save(JsonConvert.SerializeObject(content));

        }

        public object Edit(string key, string section, string contentToSave)
        {
            Content content = GetContent();

            if (!content.WebSiteHeaders.Any(x => x.BusinessName.Equals(key)))
                throw new Exception($"Not found by key: {key}");

            WebSiteHeader header = content.WebSiteHeaders.FirstOrDefault(x => x.BusinessName.Equals(key));

            header = JsonConvert.DeserializeObject<WebSiteHeader>(contentToSave);

            content.WebSiteHeaders.RemoveAt(content.WebSiteHeaders.IndexOf(header));
            content.WebSiteHeaders.Add(header);

            base.Save(JsonConvert.SerializeObject(content));

            content = GetContent();

            Object obj = new object();

            PropertyInfo[] propertyInfos = content.GetType().GetProperties();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name.Equals(section))
                {
                    return propertyInfo.GetValue(content);
                }
            }

            return null;
        }

     
    }
}
