using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nistor_Andreea_Proiect.Data;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Pages.Partners
{
    public class DetailsModel : PageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public DetailsModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

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
    }
}
