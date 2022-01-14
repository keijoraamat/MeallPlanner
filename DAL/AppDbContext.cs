﻿using Microsoft.EntityFrameworkCore;

namespace DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {
    }


    // public DbSet<Recipe> Recipes { get; set; } = default!;
    // public DbSet<Ingredient> Ingredients { get; set; } = default!;
    // public DbSet<IngredientInRecipe> IngredientInRecipes { get; set; } = default!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model
                     .GetEntityTypes()
                     .Where(e => !e.IsOwned())
                     .SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}