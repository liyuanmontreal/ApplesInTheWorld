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

namespace AppleApp.Pages.Wines
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
        public Wine Wine { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Wine == null)
            {
                return NotFound();
            }

            var wine =  await _context.Wine.FirstOrDefaultAsync(m => m.ID == id);
            if (wine == null)
            {
                return NotFound();
            }
            Wine = wine;
           ViewData["AppleID"] = new SelectList(_context.Apple, "ID", "Name");
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

            _context.Attach(Wine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(Wine.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            TempData["success"] = "Wine updated successfully";

            return RedirectToPage("./Index");
        }

        private bool WineExists(int id)
        {
          return (_context.Wine?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
