using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppleApp.Data;
using AppleApp.Model;

namespace AppleApp.Pages.Wines
{
    public class DetailsModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public DetailsModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Wine Wine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.FirstOrDefaultAsync(m => m.ID == id);
            if (wine == null)
            {
                return NotFound();
            }
            else 
            {
                Wine = wine;
            }
            return Page();
        }
    }
}
