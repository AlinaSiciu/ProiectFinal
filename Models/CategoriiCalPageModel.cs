using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using ProiectFinal.Data;

namespace ProiectFinal.Models
{
    public class CategoriiCalPageModel : PageModel
    {
        public List<AtribuireCategorie> AtribuireCategorieList;
        public void PopulateAtribuireCategorie(ProiectFinalContext context, Cal cal)
        {
            var toateCategoriile = context.Categorie;
            var calCategorie = new HashSet<int>(
                cal.CategoriiCai.Select(c => c.CategorieID));
            AtribuireCategorieList = new List<AtribuireCategorie>();
            foreach (var cat in toateCategoriile)
            {
                AtribuireCategorieList.Add(new AtribuireCategorie
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribuire = calCategorie.Contains(cat.ID)
                });
            }
        }
        public void UpdateCategoriiCai(ProiectFinalContext context, string[] selectedCategories, Cal calToUpdate)
        {
            if (selectedCategories == null)
            {
                calToUpdate.CategoriiCai = new List<CategorieCal>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var caiCategorii = new HashSet<int>(calToUpdate.CategoriiCai.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!caiCategorii.Contains(cat.ID))
                    {
                        calToUpdate.CategoriiCai.Add(new CategorieCal
                        {
                            CalID = calToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (caiCategorii.Contains(cat.ID))
                    {
                        CategorieCal calToRemove = calToUpdate
                             .CategoriiCai
                             .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(calToRemove);
                    }
                }

            }
        }

    }
}