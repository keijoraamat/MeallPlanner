using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain;

public class Category: BaseEntity
{
    [Required(ErrorMessage = "The field {0} is required")]
    [MaxLength(100)]
    public string CategoryName { get; set; } = default!;

    [MaxLength(2000)]
    public string Description { get; set; } = default!;

    public ICollection<IngredientInCategory>? IngredientInCategories { get; set; }
}