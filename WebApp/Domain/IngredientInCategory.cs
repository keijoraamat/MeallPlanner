namespace WebApp.Domain;

public class IngredientInCategory: BaseEntity
{
    public int CategoryId{ get; set; }
    public Category? Category { get; set; }
        
    public int IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }
}

