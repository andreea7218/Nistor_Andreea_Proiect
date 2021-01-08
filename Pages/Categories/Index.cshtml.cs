using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Nistor_Andreea_Proiect.Data;
using Nistor_Andreea_Proiect.Models;

namespace Nistor_Andreea_Proiect.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext _context;

        public IndexModel(Nistor_Andreea_Proiect.Data.Nistor_Andreea_ProiectContext context)
        {
            _context = context;
        }

    
        public int CategoryID { get; set; }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
