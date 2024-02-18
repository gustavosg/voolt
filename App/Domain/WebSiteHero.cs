using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class WebSiteHero : BaseEntity
    {
        public string Headline { get; set; }
        public string Description { get; set; }
        public CTAButton Button { get; set; }
        public string Image { get; set; }
        public string ImageAlignment { get; set; }
        public string ContentAlignment { get; set; }
    }
}
