public static class RecipeViewModel
{
public string id { get; set; }
public string name { get; set; }
public date dateAdded { get; set; }
public string author {get; set;}

public InstructionsViewModel Instructions { get; set; }
public IngredientsViewModel Ingredients { get; set; }

}