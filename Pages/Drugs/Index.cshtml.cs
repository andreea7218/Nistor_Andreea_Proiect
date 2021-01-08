using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nistor_Andreea_Proiect.Data;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Pages.Drugs
{
    public class IndexModel : PageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public IndexModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IList<Drug> Drug { get;set; }
        public DrugData DrugD { get; set; }
        public int DrugID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            DrugD = new DrugData();

            DrugD.Drugs = await _context.Drug
            .Include(b => b.Partner)
            .Include(b => b.DrugCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                DrugID = id.Value;
                Drug drug = DrugD.Drugs
                .Where(i => i.ID == id.Value).Single();
                DrugD.Categories = drug.DrugCategories.Select(s => s.Category);
            }
        }
    }
}
