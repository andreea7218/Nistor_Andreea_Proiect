using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nistor_Andreea_Proiect.Data;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Pages.Drugs
{
    public class EditModel : DrugCategoriesPageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public EditModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drug Drug { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drug = await _context.Drug
                 .Include(b => b.Partner)
                 .Include(b => b.DrugCategories).ThenInclude(b => b.Category)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);


            if (Drug == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Drug);
            ViewData["PartnerID"] = new SelectList(_context.Set<Partner>(), "ID", "PartnerName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var drugToUpdate = await _context.Drug
            .Include(i => i.Partner)
            .Include(i => i.DrugCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (drugToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Drug>( 
                drugToUpdate,
            "Drug",
            i => i.Name, i => i.Producer,
            i => i.Price, i => i.PublishingDate, i => i.Partner))
            {
                UpdateDrugCategories(_context, selectedCategories, drugToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateDrugCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata

            UpdateDrugCategories(_context, selectedCategories, drugToUpdate);
            PopulateAssignedCategoryData(_context, drugToUpdate);
            return Page();
        }
    }

}

