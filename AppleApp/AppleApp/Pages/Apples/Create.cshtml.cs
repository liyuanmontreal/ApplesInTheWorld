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

namespace AppleApp.Pages.Apples
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
            return Page();
        }

        [BindProperty]
        public Apple Apple { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Apple == null || Apple == null)
            {
                return Page();
            }

            _context.Apple.Add(Apple);
            await _context.SaveChangesAsync();
            TempData["success"] = "Apple created successfully";

            return RedirectToPage("./Index");
        }
    }
}
