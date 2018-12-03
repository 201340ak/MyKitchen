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
    public class IndexModel : PageModel
    {
        private readonly MyKitchen.Models.MyKitchenContext _context;

        public IndexModel(MyKitchen.Models.MyKitchenContext context)
        {
            _context = context;
        }

        public IList<InventoryEntry> InventoryEntry { get;set; }

        public async Task OnGetAsync()
        {
            InventoryEntry = await _context.InventoryEntry
                .Include(i => i.Food)
                .Include(i => i.User).ToListAsync();
        }
    }
}
