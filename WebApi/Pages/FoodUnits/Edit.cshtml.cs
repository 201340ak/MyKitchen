using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.FoodUnits
{
    public class EditModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public EditModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["Foods"] = new SelectList(_context.Food, "Id", "Name");
           ViewData["Units"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FoodUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodUnitExists(FoodUnit.Id))
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

        private bool FoodUnitExists(int id)
        {
            return _context.FoodUnit.Any(e => e.Id == id);
        }
    }
}
