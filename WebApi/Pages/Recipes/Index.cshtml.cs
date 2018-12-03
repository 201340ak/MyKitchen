using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public IndexModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipe
                .Include(r => r.User).ToListAsync();
        }
    }
}
