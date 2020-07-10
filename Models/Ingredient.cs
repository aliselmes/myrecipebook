using System;

namespace recipe_tracker.Models
{
    public class Ingredient
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string RecipeId { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }

        public string Units { get; set; }

        public override string ToString() {
            return $"{this.Id}|{this.Name}|{this.Amount}|{this.Units}\n";
            
        }
    }
}