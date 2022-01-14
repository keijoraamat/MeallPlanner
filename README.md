***Scaffolding aka instant CRUD***
```
cd WebApp
dotnet aspnet-codegenerator razorpage -m Ingredient -dc AppDbContext -udl -outDir Pages/Ingredients --referenceScriptLibraries -f
 
dotnet aspnet-codegenerator razorpage -m Recipe -dc AppDbContext -udl -outDir Pages/Recipes --referenceScriptLibraries -f

dotnet aspnet-codegenerator razorpage -m Category -dc AppDbContext -udl -outDir Pages/Categories --referenceScriptLibraries -f
 
dotnet aspnet-codegenerator razorpage -m IngredientInRecipe -dc AppDbContext -udl -outDir Pages/IngredientInRecipes --referenceScriptLibraries -f

dotnet aspnet-codegenerator razorpage -m IngredientInCategory -dc AppDbContext -udl -outDir Pages/IngredientInCategories --referenceScriptLibraries -f
```