using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Content
    {
        public List<WebSiteHeader> WebSiteHeaders { get; set; } = new();
        public List<WebSiteHero> WebSiteHeroes { get; set; } = new();
        public List<Services> Services { get; set; } = new();
    }

}
