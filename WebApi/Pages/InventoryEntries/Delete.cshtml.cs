using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyKitchen.Models;

namespace MyKitchen.Pages.InventoryEntries
{
    public class DeleteModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public DeleteModel(MyKitchen.Models.MyKitchenContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InventoryEntry = await _context.InventoryEntry.FindAsync(id);

            if (InventoryEntry != null)
            {
                _context.InventoryEntry.Remove(InventoryEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
