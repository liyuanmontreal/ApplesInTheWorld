using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppleApp.Data;
using AppleApp.Model;

namespace AppleApp.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public IndexModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Recipe != null)
            {
                Recipe = await _context.Recipe
                .Include(r => r.Apple).ToListAsync();
            }
        }
    }
}
