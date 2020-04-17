using System;
namespace recipe_tracker.Models
{

    public class Recipe
    {
        public string id { get; set; }
        public string name { get; set; }
        public DateTime dateAdded { get; set; }
        public string author { get; set; }

        public InstructionsViewModel Instructions { get; set; }
        public IngredientsViewModel Ingredients { get; set; }

    }

}