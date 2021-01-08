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

namespace Nistor_Andreea_Proiect.Pages.Partners
{
    public class EditModel : PageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public EditModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Partner Partner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Partner = await _context.Partner.FirstOrDefaultAsync(m => m.ID == id);

            if (Partner == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Partner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartnerExists(Partner.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PartnerExists(int id)
        {
            return _context.Partner.Any(e => e.ID == id);
        }
    }
}
