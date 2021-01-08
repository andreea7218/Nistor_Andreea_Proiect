using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Data
{
    public class Nistor_Andreea_ProiectContext : DbContext
    {
        public Nistor_Andreea_ProiectContext (DbContextOptions<Nistor_Andreea_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Nistor_Andreea_Proiect.Models.Drug> Drug { get; set; }

        public DbSet<Nistor_Andreea_Proiect.Models.Partner> Partner { get; set; }

        public DbSet<Nistor_Andreea_Proiect.Models.Category> Category { get; set; }

       
    }
}
