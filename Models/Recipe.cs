using System.Linq;
using System;
using System.Collections.Generic;


namespace recipe_tracker.Models
{
    public class Recipe
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public string Author { get; set; }

        public IList<Instruction> Instructions { get; set; } = new List<Instruction>();

        public IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public override string ToString() {
            var output = $"{this.Id}|{this.Name}|{this.DateAdded.ToString()}|{this.Author}\n";
            output+=string.Join(' ',this.Instructions.Select(x=>x.ToString()));
            output+=string.Join(' ',this.Ingredients.Select(x=>x.ToString()));
            return output;
        }
    }
}
