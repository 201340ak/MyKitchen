using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKitchen.Models;

namespace MyKitchen.Pages.Ingredients
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
        ViewData["Foods"] = new SelectList(_context.Food, "Id", "Name");
        ViewData["Recipes"] = new SelectList(_context.Recipe, "Id", "Name");
        ViewData["SelectedUnits"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        [BindProperty]
        public Ingredient Ingredient { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Ingredient.Add(Ingredient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}