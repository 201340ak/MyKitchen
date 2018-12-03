using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKitchen.Models;

namespace MyKitchen.Pages.Units
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
            return Page();
        }

        [BindProperty]
        public Unit Unit { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Unit.Add(Unit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}