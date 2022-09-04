using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppleApp.Data;
using AppleApp.Model;

namespace AppleApp.Pages.Apples
{
    public class IndexModel : PageModel
    {
        private readonly AppleApp.Data.ApplicationDbContext _context;

        public IndexModel(AppleApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Apple> Apple { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }      
        public SelectList? Locations { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AppleLocation { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? AppleSort { get; set; }


        public async Task OnGetAsync()
        {
            //get all 
            //if (_context.Apple != null)
            //{
            //    Apple = await _context.Apple.ToListAsync();
            //}

            
            // Use LINQ to get list of locations.
            IQueryable<string> locationQuery = from a in _context.Apple
                                            orderby a.Location
                                            select a.Location;
            // using system.linq
            var apples = from a in _context.Apple                         
                         select a;

            //lambda 
            if (!string.IsNullOrEmpty(SearchString))
            {
                apples = apples.Where(s => s.Name.Contains(SearchString));
                apples = apples.OrderBy(s => s.Rank);
            }

            if (!string.IsNullOrEmpty(AppleLocation))
            {
                apples = apples.Where(x => x.Location == AppleLocation);
                apples = apples.OrderBy(s => s.Rank);
            }
            Locations = new SelectList(await locationQuery.Distinct().ToListAsync());


            if (!string.IsNullOrEmpty(AppleSort))
            {
                

                apples = AppleSort switch
                {
                    "Best Rated" => from b in _context.Apple
                                    orderby b.Rate descending
                                    select b,
                    "Alphabetically" => from b in _context.Apple
                                        orderby b.Name
                                        select b,
                    "By Location" => from b in _context.Apple
                                     orderby b.Location
                                     select b,
                    _ => from b in _context.Apple
                         orderby b.Rank
                         select b,
                };
            }

            Apple = await apples.ToListAsync();
        }
    }
}
