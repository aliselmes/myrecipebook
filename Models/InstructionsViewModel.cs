namespace recipe_tracker.Models
{
    public class InstructionsViewModel
    {

        public string id { get; set; }
        public string recipeId { get; set; }
        public int stepNumber { get; set; }
        public string instructions { get; set; }

    }
}