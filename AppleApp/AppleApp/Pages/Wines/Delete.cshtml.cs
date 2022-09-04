using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppleApp.Data;
using AppleApp.Model;
using Microsoft.AspNetCore.Authorization;

namespace AppleApp.Pages.Wines
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public DeleteModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }
            var wine = await _context.Wine.FindAsync(id);

            if (wine != null)
            {
                Wine = wine;
                _context.Wine.Remove(Wine);
                await _context.SaveChangesAsync();
            }
            TempData["delete"] = "Wine Deleted successfully";

            return RedirectToPage("./Index");
        }
    }
}
