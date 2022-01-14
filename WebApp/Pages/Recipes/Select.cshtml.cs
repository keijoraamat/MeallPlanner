#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Domain;

namespace WebApp.Pages.Recipes;

public class Select : PageModel
{
    private readonly WebApp.DAL.AppDbContext _context;

    public Select(WebApp.DAL.AppDbContext context)
    {
        _context = context;
    }

    public Recipe Recipe { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<IngredientInRecipe> Amounts { get; set; }
    public int[] RecipeAmounts { get; set; } = default!;
    public int Servings { get; set; } = 1;

    public async Task<IActionResult> OnGetAsync(int? id, int? servings)
    {
        if (id == null)
        {
            return NotFound();
        }

        if (servings != null)
        {
            Servings = servings.Value;
        }

        Recipe = _context.Recipes
            .Include(x => x.IngredientInRecipes!)
            .ThenInclude(y => y.Ingredient)
            .FirstOrDefault(m => m.Id == id);

        Ingredients = _context.Ingredients
            .Where(r => r.IngredientInRecipes!.Any(w => w.RecipeId == id)).ToList();

        Amounts = _context.IngredientInRecipes.Where(r => r.RecipeId == id).ToList();

        RecipeAmounts = new int[Amounts.Count];
        for (var i = 0; i < Amounts.Count; i++)
        {
            RecipeAmounts[i] = Amounts[i].Weight * Servings;
        }
            

        if (Recipe == null)
        {
            return NotFound();
        }
        return Page();
        
    }
}