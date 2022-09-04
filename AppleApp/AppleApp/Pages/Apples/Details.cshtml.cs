using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppleApp.Data;
using AppleApp.Model;

namespace AppleApp.Pages.Apples
{
    public class DetailsModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public DetailsModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Apple Apple { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Apple == null)
            {
                return NotFound();
            }

            var apple = await _context.Apple.FirstOrDefaultAsync(m => m.ID == id);
            if (apple == null)
            {
                return NotFound();
            }
            else 
            {
                Apple = apple;
            }
            return Page();
        }
    }
}
