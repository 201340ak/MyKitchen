using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.FoodUnits
{
    public class IndexModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public IndexModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public IList<FoodUnit> FoodUnit { get;set; }

        public async Task OnGetAsync()
        {
            FoodUnit = await _context.FoodUnit
                .Include(f => f.Food)
                .Include(f => f.Unit).ToListAsync();
        }
    }
}
