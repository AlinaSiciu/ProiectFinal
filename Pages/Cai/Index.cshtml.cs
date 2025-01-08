using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;
using ProiectFinal.Models;

namespace ProiectFinal.Pages.Cai
{
    public class IndexModel : PageModel
    {
        private readonly ProiectFinal.Data.ProiectFinalContext _context;

        public IndexModel(ProiectFinal.Data.ProiectFinalContext context)
        {
            _context = context;
        }

        public IList<Cal> Cal { get; set; } = default!;
        public CalData CalD { get; set; }
        public int CalID { get; set; }
        public int CategorieID { get; set; }

        public async Task OnGetAsync(int? id, int? categorieID)
        {
            CalD = new CalData();

            //se va include Author conform cu sarcina de la lab 2
            CalD.Cai = await _context.Cal
            .Include(b => b.Instructor)
            .Include(b => b.CategoriiCai)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.NumeCal)
            .ToListAsync();
            if (id != null)
            {
                CalID = id.Value;
                Cal cal = CalD.Cai
                .Where(i => i.ID == id.Value).Single();
                CalD.Categorii = cal.CategoriiCai.Select(s => s.Categorie);
            }
        }
    }
}
