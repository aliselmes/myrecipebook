namespace recipe_tracker.services 
{
    public static class DatabaseService : IDatabaseConnection
    {
        public static Get(string id) {
            // Code to get data C _R_ U D
            public IHttpActionResult GetAllRecipes () 
            {

            }
        }

        public static Save (object data) {
            // Code to save data _C_ R U D
            Post ("http://localhost:5001/recipes/") 
                {
                "recipe": {
                    "ingredients": {
                        "name": "",
                        "amount": "",
                        "measurement": ""
                    },
                    "instructions": {
                        "stepNumber": "",
                        "instructions": ""
                    }
                }
            }
            // OR If data already exists, C R _U_ D

        }

        public static Delete (string id) {
            // Code to Delete data C R U _D_
        }
    }
}