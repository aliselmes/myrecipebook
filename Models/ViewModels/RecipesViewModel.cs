using System.Collections.Generic;
namespace recipe_tracker.Models.ViewModels
{
    public class RecipesViewModel
    {
        public IList<Recipe> Recipes {get; set;}
    }

    public class RecipeViewModel
    {
        public Recipe Recipe {get; set;}
    }
    
};

