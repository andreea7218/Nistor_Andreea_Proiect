using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nistor_Andreea_Proiect.Models
{
    public class Partner
    {
        public int ID { get; set; }
        public string PartnerName { get; set; }
        public ICollection<Drug> Drugs { get; set; }
    }
}
