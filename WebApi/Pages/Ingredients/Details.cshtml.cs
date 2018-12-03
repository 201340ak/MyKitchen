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
    public class DetailsModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public DetailsModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ingredient = await _context.Ingredient
                .Include(i => i.Food)
                .Include(i => i.Recipe)
                .Include(i => i.SelectedUnit).FirstOrDefaultAsync(m => m.Id == id);

            if (Ingredient == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
