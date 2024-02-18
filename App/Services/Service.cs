using Core.Domain;
using Domain;
using Newtonsoft.Json;
using Repository;

namespace Services
{
    public class Service : IService
    {
        private readonly IRepository repository;

        public Service(
            IRepository repository
            )
        {
            this.repository = repository;

        }
        public Object Get(string sectionId, string key)
        {
            return JsonConvert.SerializeObject(repository.Get(sectionId, key));
        }

        public Content GetAll()
        => repository.GetAll();


        public void Add()
        {
            Content content = new();

            List<NavigationMenu> menus = new List<NavigationMenu>()
            {
                new () { Path = "./wwwroot/images/logo1.png", Title = "Logo 1"},
                new () { Path = "./wwwroot/images/logo2.png", Title = "Logo 2"},
                new () { Path = "./wwwroot/images/logo3.png", Title = "Logo 3"},
            };

            #region headers

            content.WebSiteHeaders.Add(new WebSiteHeader()
            {
                Id = "handyMan",
                BlockOrder = 0,
                BusinessName = "Handy Man",
                Logo = "",
                NavigationMenus = menus,
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Button Text"
                }
            });

            content.WebSiteHeaders.Add(new WebSiteHeader()
            {
                Id = "MyBusinessMan",
                BlockOrder = 1,
                BusinessName = "Business Man",
                Logo = "",
                NavigationMenus = menus,
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Button Text"
                }
            });

            content.WebSiteHeaders.Add(new WebSiteHeader()
            {
                Id = "CorporatePerson",
                BlockOrder = 2,
                BusinessName = "Corporate Person",
                Logo = "",
                NavigationMenus = menus,
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Button Text"
                }
            });

            #endregion

            #region heroes
            content.WebSiteHeroes.Add(new()
            {
                Id = "heroes1",
                BlockOrder = 0,
                Headline = "Headline 1",
                Description = "Description 1",
                Image = "./wwwroot/images/heroes1.png",
                ContentAlignment = "justify",
                ImageAlignment = "center",
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Hero Text 1"
                }
            });

            content.WebSiteHeroes.Add(new()
            {
                Id = "heroes2",
                BlockOrder = 1,
                Headline = "Headline 2",
                Description = "Description 2",
                Image = "./wwwroot/images/heroes2.png",
                ContentAlignment = "justify",
                ImageAlignment = "center",
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Hero Text 2"
                }
            });

            content.WebSiteHeroes.Add(new()
            {
                Id = "heroes3",
                BlockOrder = 2,
                Headline = "Headline 3",
                Description = "Description 3",
                Image = "./wwwroot/images/heroes3.png",
                ContentAlignment = "justify",
                ImageAlignment = "center",
                Button = new()
                {
                    Event = "click",
                    Icon = "icon",
                    Status = "OK",
                    Text = "Hero Text 3"
                }
            });

            #endregion

            #region services

            content.Services.Add(new()
            {
                Id = "Service1",
                BlockOrder = 0,
                Headline = "Headline 1",
                ServiceCard = new()
                {
                    Button = new()
                    {
                        Event = "click",
                        Icon = "icon",
                        Status = "OK",
                        Text = "Service Text 1"
                    },
                    Description = "Service Description 1",
                    Image = "./wwwroot/images/service1.png",
                    Name = "Service Name 1"
                }
            });

            content.Services.Add(new()
            {
                Id = "Service2",
                BlockOrder = 1,
                Headline = "Headline 2",
                ServiceCard = new()
                {
                    Button = new()
                    {
                        Event = "click",
                        Icon = "icon",
                        Status = "OK",
                        Text = "Service Text 2"
                    },
                    Description = "Service Description 2",
                    Image = "./wwwroot/images/service2.png",
                    Name = "Service Name 2"
                }
            });

            content.Services.Add(new()
            {
                Id = "Service3",
                BlockOrder = 2,
                Headline = "Headline 3",
                ServiceCard = new()
                {
                    Button = new()
                    {
                        Event = "click",
                        Icon = "icon",
                        Status = "OK",
                        Text = "Service Text 3"
                    },
                    Description = "Service Description 3",
                    Image = "./wwwroot/images/service3.png",
                    Name = "Service Name 3"
                }
            });

            #endregion

            repository.Save(content);
        }


        public Object Edit(string key, string section, Object model)
        {
            Content content = repository.GetContent();

            string contentToSave = System.Text.Json.JsonSerializer.Serialize(model);

            switch (section.ToUpperInvariant())
            {
                case "WEBSITEHEADERS":
                    {
                        WebSiteHeader objSave = content.WebSiteHeaders.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.WebSiteHeaders.IndexOf(objSave);

                        objSave.Id = objSave.Id.Replace(" ", String.Empty);
                        objSave = JsonConvert.DeserializeObject<WebSiteHeader>(contentToSave);

                        content.WebSiteHeaders.RemoveAt(index);
                        content.WebSiteHeaders.Add(objSave);

                        break;
                    }
                case "WEBSITEHEROES":
                    {
                        WebSiteHero objSave = content.WebSiteHeroes.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.WebSiteHeroes.IndexOf(objSave);

                        objSave.Id = objSave.Id.Replace(" ", String.Empty);
                        objSave = JsonConvert.DeserializeObject<WebSiteHero>(contentToSave);

                        content.WebSiteHeroes.RemoveAt(index);
                        content.WebSiteHeroes.Add(objSave);

                        break;
                    }
                case "SERVICES":
                    {
                        Domain.Services objSave = content.Services.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.Services.IndexOf(objSave);

                        objSave.Id = objSave.Id.Replace(" ", String.Empty);
                        objSave = JsonConvert.DeserializeObject<Domain.Services>(contentToSave);

                        content.Services.RemoveAt(index);
                        content.Services.Add(objSave);

                        break;
                    }
                default:
                    break;
            }

            repository.Save(content);

            return true;
        }

        public void Delete(string key, string section)
        {
            Content content = repository.GetContent();

            switch (section.ToUpperInvariant())
            {
                case "WEBSITEHEADERS":
                    {
                        WebSiteHeader objDelete = content.WebSiteHeaders.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.WebSiteHeaders.IndexOf(objDelete);
                        content.WebSiteHeaders.RemoveAt(index);

                        repository.Save(content);
                        break;
                    }
                case "WEBSITEHEROES":
                    {
                        WebSiteHero objDelete = content.WebSiteHeroes.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.WebSiteHeroes.IndexOf(objDelete);
                        content.WebSiteHeroes.RemoveAt(index);

                        repository.Save(content);

                        break;
                    }
                case "SERVICES":
                    {
                        Domain.Services objDelete = content.Services.FirstOrDefault(x => x.Id.Equals(key));
                        int index = content.Services.IndexOf(objDelete);

                        content.Services.RemoveAt(index);

                        repository.Save(content);
                        break;
                    }
            }
        }
    }
}
