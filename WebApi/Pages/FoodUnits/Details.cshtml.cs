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
    public class DetailsModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public DetailsModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public FoodUnit FoodUnit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodUnit = await _context.FoodUnit
                .Include(f => f.Food)
                .Include(f => f.Unit).FirstOrDefaultAsync(m => m.Id == id);

            if (FoodUnit == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
