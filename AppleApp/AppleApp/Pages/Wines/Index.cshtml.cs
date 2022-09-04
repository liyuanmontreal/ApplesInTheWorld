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
    public class IndexModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public IndexModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Wine> Wine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Wine != null)
            {
                Wine = await _context.Wine
                .Include(w => w.Apple).ToListAsync();
            }
        }
    }
}
