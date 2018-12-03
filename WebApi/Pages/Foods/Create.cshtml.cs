using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKitchen.Models;

namespace MyKitchen.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public CreateModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Units"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}