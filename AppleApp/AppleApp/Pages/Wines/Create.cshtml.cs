using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppleApp.Data;
using AppleApp.Model;
using Microsoft.AspNetCore.Authorization;

namespace AppleApp.Pages.Wines
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public CreateModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AppleID"] = new SelectList(_context.Apple, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Wine Wine { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Wine == null || Wine == null)
            {
                return Page();
            }

            _context.Wine.Add(Wine);
            await _context.SaveChangesAsync();

            TempData["success"] = "Wine created successfully";

            return RedirectToPage("./Index");
        }
    }
}
