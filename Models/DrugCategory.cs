using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nistor_Andreea_Proiect.Models
{
    public class DrugCategory
    {
        public int ID { get; set; }
        public int DrugID { get; set; }
        public Drug Drug { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
