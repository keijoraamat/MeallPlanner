#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Domain;

namespace WebApp.Pages.IngredientInRecipes
{
    public class DetailsModel : PageModel
    {
        private readonly WebApp.DAL.AppDbContext _context;

        public DetailsModel(WebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IngredientInRecipe IngredientInRecipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IngredientInRecipe = await _context.IngredientInRecipes
                .Include(i => i.Ingredient)
                .Include(i => i.Recipe).FirstOrDefaultAsync(m => m.Id == id);

            if (IngredientInRecipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
