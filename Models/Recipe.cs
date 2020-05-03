using System;
namespace recipe_tracker.Models
{

    public class Recipe
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Author { get; set; }

        public InstructionsViewModel Instructions { get; set; }
        public IngredientsViewModel Ingredients { get; set; }

    }

}