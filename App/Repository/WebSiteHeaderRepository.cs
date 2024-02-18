
using Domain;
using System.Text.Json;

namespace Repository
{
    public class WebSiteHeaderRepository : Repository, IWebSiteHeaderRepository
    {
        string textJsonFile = String.Empty;

        public WebSiteHeaderRepository() {
            Prepare();
        }

        private async void Prepare()
        {
            textJsonFile = await base.Get();

            if (String.IsNullOrWhiteSpace(textJsonFile))
            {
                Content content = new();
                textJsonFile = System.Text.Json.JsonSerializer.Serialize(content);

                await base.Save(textJsonFile);
            }
        }

        private async Task<Content> GetContent()
        {
            textJsonFile = await base.Get();

            return JsonSerializer.Deserialize<Content>(textJsonFile);
        }


        public async Task<WebSiteHeader> Get(string key)
        {
            Content content = await GetContent();

            if (content.WebSiteHeaders.Any(x => !x.BusinessName.Equals(key)))
                throw new Exception("Not Found");

            return content.WebSiteHeaders.FirstOrDefault(x => x.BusinessName.Equals(key, StringComparison.Ordinal)) ?? null;
        }

        public async Task Save(string key, string contentToSave)
        {
            Content content = await GetContent();

            if (!content.WebSiteHeaders.Any(x => x.BusinessName.Equals(key)))
                throw new Exception($"Not found by key: {key}");

            WebSiteHeader header = content.WebSiteHeaders.FirstOrDefault(x => x.BusinessName.Equals(key));

            header = JsonSerializer.Deserialize<WebSiteHeader>(contentToSave);

            content.WebSiteHeaders.RemoveAt(content.WebSiteHeaders.IndexOf(header));
            content.WebSiteHeaders.Add(header);

            await base.Save(JsonSerializer.Serialize(content));
        }
    }
}
