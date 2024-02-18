using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class ServiceCard
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public CTAButton Button { get; set; }
    }
}
