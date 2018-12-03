using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public IndexModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
            _context.Food.Include(food => food.AvailableFoodUnits);
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Food.Include(food => food.AvailableFoodUnits).ToListAsync();
        }
    }
}
