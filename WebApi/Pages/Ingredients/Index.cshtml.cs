using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.Ingredients
{
    public class IndexModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public IndexModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public IList<Ingredient> Ingredient { get;set; }

        public async Task OnGetAsync()
        {
            Ingredient = await _context.Ingredient
                .Include(i => i.Food)
                .Include(i => i.Recipe)
                .Include(i => i.SelectedUnit).ToListAsync();
        }
    }
}
