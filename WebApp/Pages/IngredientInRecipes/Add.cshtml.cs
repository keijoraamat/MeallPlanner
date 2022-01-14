#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.DAL;
using WebApp.Domain;

namespace WebApp.Pages.IngredientInRecipes
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.DAL.AppDbContext _context;
        public List<SelectList> RecipeTitles { get; set; }

        public CreateModel(WebApp.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IngredientId"] = new SelectList(_context.Ingredients, "Id", "IngredientName");
        ViewData["RecipeTitle"] = new SelectList(_context.Recipes, "Id", "Title");
        //RecipeTitles.Add( new SelectListItem(_context.Recipes,"Id", "Title"));
            return Page();
        }

        [BindProperty]
        public IngredientInRecipe IngredientInRecipe { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IngredientInRecipes.Add(IngredientInRecipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
