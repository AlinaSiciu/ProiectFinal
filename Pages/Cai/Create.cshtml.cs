using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectFinal.Data;
using ProiectFinal.Models;
using ProiectFinal.Models;

namespace ProiectFinal.Pages.Cai
{
    public class CreateModel : CategoriiCalPageModel
    {
        private readonly ProiectFinal.Data.ProiectFinalContext _context;

        public CreateModel(ProiectFinal.Data.ProiectFinalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "ID", "FullName");
            var cal = new Cal();
            cal.CategoriiCai = new List<CategorieCal>();

            PopulateAtribuireCategorie(_context, cal);
            return Page();
        }

        [BindProperty]
        public Cal Cal { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newCal = new Cal();
            if (selectedCategories != null)
            {
                newCal.CategoriiCai = new List<CategorieCal>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new CategorieCal
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newCal.CategoriiCai.Add(catToAdd);
                }
            }
            Cal.CategoriiCai = newCal.CategoriiCai;
            _context.Cal.Add(Cal);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}