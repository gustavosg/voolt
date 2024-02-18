using Core.Domain;

namespace Domain
{
    public class WebSiteHeader : BaseEntity
    {
        public string BusinessName { get; set; }
        public string Logo { get; set; }
        public List<NavigationMenu> NavigationMenus { get; set; }
        public CTAButton Button { get; set; }

    }
}
