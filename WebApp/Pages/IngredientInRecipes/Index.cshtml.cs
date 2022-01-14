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
    public class IndexModel : PageModel
    {
        private readonly WebApp.DAL.AppDbContext _context;

        public IndexModel(WebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<IngredientInRecipe> IngredientInRecipe { get;set; }

        public async Task OnGetAsync()
        {
            IngredientInRecipe = await _context.IngredientInRecipes
                .Include(i => i.Ingredient)
                .Include(i => i.Recipe).ToListAsync();
        }
    }
}
