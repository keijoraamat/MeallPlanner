using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain;

public class Ingredient: BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(120)]
    public string IngredientName { get; set; } = default!;
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(50)]
    public string State { get; set; } = default!;
    
    public float? Density { get; set; } = default!;

    public ICollection<IngredientInRecipe>? IngredientInRecipes { get; set; }
    public ICollection<IngredientInCategory>? IngredientInCategories { get; set; }
}