using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Data;
using ProiectFinal.Models;
using ProiectFinal.Models;

namespace ProiectFinal.Pages.Cai
{
    public class EditModel : CategoriiCalPageModel
    {
        private readonly ProiectFinal.Data.ProiectFinalContext _context;

        public EditModel(ProiectFinal.Data.ProiectFinalContext context)
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

            var cal = await _context.Cal.Include(b => b.Instructor).Include(b => b.CategoriiCai).ThenInclude(b => b.Categorie).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            if (cal == null)
            {
                return NotFound();
            }

            PopulateAtribuireCategorie(_context, Cal);
            var instructorList = _context.Instructor.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });
            ViewData["InstructorID"] = new SelectList(_context.Set<Instructor>(), "ID", "FullName");
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var calToUpdate = await _context.Cal
                .Include(i => i.Instructor)
                .Include(i => i.CategoriiCai)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Cal>(
                calToUpdate,
                "Cal",
                i => i.NumeCal, i => i.InstructorID,
                i => i.AnulNasterii))
            {
                UpdateCategoriiCai(_context, selectedCategories, calToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCategoriiCai(_context, selectedCategories, calToUpdate);
            PopulateAtribuireCategorie(_context, calToUpdate);
            return Page();
        }

        private bool CalExists(int id)
        {
            return _context.Cal.Any(e => e.ID == id);
        }
    }
}
