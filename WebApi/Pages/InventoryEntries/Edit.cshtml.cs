using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.InventoryEntries
{
    public class EditModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public EditModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventoryEntry InventoryEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventoryEntry = await _context.InventoryEntry
                .Include(i => i.Food)
                .Include(i => i.User).FirstOrDefaultAsync(m => m.Id == id);

            if (InventoryEntry == null)
            {
                return NotFound();
            }
            ViewData["Foods"] = new SelectList(_context.Food, "Id", "Name");
            ViewData["Users"] = new SelectList(_context.User, "Id", "DisplayName");
            ViewData["Units"] = new SelectList(_context.Unit, "Id", "SingularName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventoryEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryEntryExists(InventoryEntry.Id))
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

        private bool InventoryEntryExists(int id)
        {
            return _context.InventoryEntry.Any(e => e.Id == id);
        }
    }
}
