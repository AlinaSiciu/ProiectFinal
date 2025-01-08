using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;

namespace ProiectFinal.Pages.Cai
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectFinal.Data.ProiectFinalContext _context;

        public DeleteModel(ProiectFinal.Data.ProiectFinalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cal Cal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cal = await _context.Cal.FirstOrDefaultAsync(m => m.ID == id);

            if (cal == null)
            {
                return NotFound();
            }
            else
            {
                Cal = cal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cal = await _context.Cal.FindAsync(id);
            if (cal != null)
            {
                Cal = cal;
                _context.Cal.Remove(Cal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
