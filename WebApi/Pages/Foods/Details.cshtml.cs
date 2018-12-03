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
    public class DetailsModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public DetailsModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food.FirstOrDefaultAsync(m => m.Id == id);

            if (Food == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
