using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyKitchen.Models;

namespace MyKitchen.Pages.InventoryEntries
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
        ViewData["Users"] = new SelectList(_context.User, "Id", "DisplayName");
        ViewData["Units"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        [BindProperty]
        public InventoryEntry InventoryEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InventoryEntry.Add(InventoryEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}