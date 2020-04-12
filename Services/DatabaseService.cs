using Dapper;
using recipe_tracker.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace recipe_tracker.services
{
    public static class DatabaseService : IDatabaseConnection
    {
        public static string GetConnection()
        {
            return "Server=localhost;Uid=recipetracker;Pwd=a;Database=recipe_tracker";


            /*
            Configuration.GetSection("ConnectionString")["RecipeDb"];
            */
            
        }
        public static IList<RecipeViewModel> Get(string id)
        {
            // Code to get data C _R_ U D
            using (IDbConnection db = new SqlConnection(GetConnection()))
            {
                var recipe = db.Query<RecipeViewModel>("Select * From Recipes").ToList();
            }
            return recipe;
        }

        public static bool Save(object data)
        {
            // Code to save data _C_ R U D
            return false;
            // OR If data already exists, C R _U_ D

        }

        public static bool Delete(string id)
        {
            return false;
            // Code to Delete data C R U _D_
        }
    }
}