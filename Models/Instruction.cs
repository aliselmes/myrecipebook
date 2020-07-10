using System;

namespace recipe_tracker.Models
{
    public class Instruction
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();

        public string RecipeId { get; set; }

        public int Stepnumber { get; set; }

        public string Text { get; set; }

        public override string ToString() {
            return $"{this.Id}|{this.Stepnumber}|{this.Text}\n";
        }
    }
}