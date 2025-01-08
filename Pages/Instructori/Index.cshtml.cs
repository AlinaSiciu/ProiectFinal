using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;

namespace ProiectFinal.Pages.Instructori
{
    public class IndexModel : PageModel
    {
        private readonly ProiectFinal.Data.ProiectFinalContext _context;

        public IndexModel(ProiectFinal.Data.ProiectFinalContext context)
        {
            _context = context;
        }

        public IList<Instructor> Instructor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Instructor = await _context.Instructor.ToListAsync();
        }
    }
}
