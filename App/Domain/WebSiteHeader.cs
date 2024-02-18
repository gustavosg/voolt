namespace Domain
{
    public class WebSiteHeader : BaseEntity
    {
        public string BusinessName { get; set; }
        public string Logo { get; set; }
        public NavigationMenu NavigationMenu { get; set; }
        public CTAButton Button { get; set; }

    }
}
