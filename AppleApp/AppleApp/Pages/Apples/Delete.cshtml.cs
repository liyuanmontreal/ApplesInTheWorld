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

namespace AppleApp.Pages.Apples
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Apple == null)
            {
                return NotFound();
            }
            var apple = await _context.Apple.FindAsync(id);

            if (apple != null)
            {
                Apple = apple;
                _context.Apple.Remove(Apple);
                await _context.SaveChangesAsync();
            }
            TempData["delete"] = "Apple Deleted successfully";
            return RedirectToPage("./Index");
        }
    }
}
