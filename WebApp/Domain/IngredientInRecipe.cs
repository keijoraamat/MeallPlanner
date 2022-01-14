using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain;

public class IngredientInRecipe
{
    [Required(ErrorMessage = "The field {0} is required")]
    public int Weight { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(1026)]
    public string Comment { get; set; } = default!;

    public int RecipeId { get; set; }
    public Recipe? Recipe { get; set; }
    
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }

}