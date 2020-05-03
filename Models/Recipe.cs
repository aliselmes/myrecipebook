using System;
using System.Collections.Generic;

namespace recipe_tracker.Models
{
    public class Recipe
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public string Author { get; set; }

        public IList<Instruction> Instructions { get; set; }

        public IList<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Amount { get; set; }

        public string Units { get; set; }
    }

    public class Instruction
    {
        public string Id { get; set; }

        public int Stepnumber { get; set; }

        public string Text { get; set; }
    }
}