using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain;

public class Recipe: BaseEntity
{
    [MaxLength(80)]
    public string Title { get; set; } = default!;
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(2576)]
    public string Description { get; set; } = default!;

    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(9588)]
    public string Instructions { get; set; } = default!;

    public int? DefaultServings { get; set; }
    
    public int PrepMinutes { get; set; }
    
    public ICollection<IngredientInRecipe>? IngredientInRecipes { get; set; }
}