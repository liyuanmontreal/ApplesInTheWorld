using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppleApp.Data;
using AppleApp.Model;
using Microsoft.AspNetCore.Authorization;

namespace AppleApp.Pages.Apples
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public EditModel(AppleApp.Data.ApplicationDbContext context)
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

            var apple =  await _context.Apple.FirstOrDefaultAsync(m => m.ID == id);
            if (apple == null)
            {
                return NotFound();
            }
            Apple = apple;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Apple).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppleExists(Apple.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["success"] = "Apple updated successfully";

            return RedirectToPage("./Index");
        }

        private bool AppleExists(int id)
        {
          return (_context.Apple?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
