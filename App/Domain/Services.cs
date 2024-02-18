using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Services : BaseEntity
    {
        public string Headline { get; set; }
        public ServiceCard ServiceCard { get; set; }
    }
}
