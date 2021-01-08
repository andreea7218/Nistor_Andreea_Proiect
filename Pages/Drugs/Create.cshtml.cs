using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nistor_Andreea_Proiect.Data;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Pages.Drugs
{
    public class CreateModel : DrugCategoriesPageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public CreateModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PartnerID"] = new SelectList(_context.Set<Partner>(), "ID", "PartnerName");
    

            var drug = new Drug();
            drug.DrugCategories = new List<DrugCategory>();
            PopulateAssignedCategoryData(_context, drug);

            return Page();
        }

        [BindProperty]
        public Drug Drug { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDrug = new Drug();
            if (selectedCategories != null)
            {
                newDrug.DrugCategories = new List<DrugCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new DrugCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDrug.DrugCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Drug>(
            newDrug,
            "Drug",
            i => i.Name, i => i.Producer,
            i => i.Price, i => i.PublishingDate, i => i.PartnerID))
            {
                _context.Drug.Add(newDrug);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDrug);
            return Page();
        }
    }
}
