namespace recipe_tracker.Models
{
    public class IngredientsViewModel
    {
        public string id { get; set; }
        public string recipeId { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public string measurement { get; set; }
    }
}