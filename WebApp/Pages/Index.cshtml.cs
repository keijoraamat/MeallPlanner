using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Domain;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly WebApp.DAL.AppDbContext _context;

    public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IList<Recipe> Recipe { get;set; } = default!;

    public string? SearchName { get; set; }
    public string? SearchIngredient { get; set; }
    
    public async Task OnGetAsync(string? searchName, string? searchIngredient, string action)
    {
        if (action == "Clear")
        {
            searchName = null;
            searchIngredient = null;
        }

        SearchName = searchName;
        SearchIngredient = searchIngredient;
        

        var recipeQuery = _context.Recipes
            .Include(x => x.IngredientInRecipes!)
            .ThenInclude(y => y.Ingredient)
            .AsQueryable();
        if (!string.IsNullOrWhiteSpace(searchName))
        {
            searchName = searchName.Trim();
            recipeQuery = recipeQuery.Where(r => 
                r.Title.ToUpper().Contains(searchName.ToUpper()) ||
                r.Description.ToUpper().Contains(searchName.ToUpper()));
        }

        if (!string.IsNullOrWhiteSpace(searchIngredient))
        {
            var searchIngredients = searchIngredient.Trim().Split(",");
            for (var i = 0; i < searchIngredients.Length; i++)
            {
                searchIngredients[i] = searchIngredients[i].Trim();
            }

            // get data from db to memory
            Recipe = await recipeQuery.ToListAsync();
            
            // filter it in memory
            Recipe = Recipe.Where(r => 
                    r.IngredientInRecipes!.Any(i => 
                        searchIngredients.Any(s => i.Ingredient!.IngredientName.ToUpper().Contains(s.ToUpper()))))
                .ToList();
        }
        else
        {
            Recipe = await recipeQuery.ToListAsync();
        }


    }

}