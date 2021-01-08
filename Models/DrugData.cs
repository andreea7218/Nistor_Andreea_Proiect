using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nistor_Andreea_Proiect.Models
{
    public class DrugData
    {
        public IEnumerable<Drug> Drugs { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<DrugCategory> DrugCategories { get; set; }
    }
}
