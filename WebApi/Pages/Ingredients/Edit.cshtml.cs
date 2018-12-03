using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.Ingredients
{
    public class EditModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public EditModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        [BindProperty]
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
            ViewData["Foods"] = new SelectList(_context.Food, "Id", "Name");
            ViewData["Recipes"] = new SelectList(_context.Recipe, "Id", "Name");
            ViewData["SelectedUnits"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(Ingredient.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.Id == id);
        }
    }
}
