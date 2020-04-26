using System;
using Dapper;
using recipe_tracker.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient; 

namespace recipe_tracker.services
{
    public static class DatabaseService //: IDatabaseConnection
    {
        public static string GetConnection()
        {
            return "Server=localhost;Port=8889;Uid=recipetracker;Pwd=a;Database=recipe_tracker";


            /*
            Configuration.GetSection("ConnectionString")["RecipeDb"];
            */
            
        }
        public static IList<Recipe> GetAll()
        {
            
            using (IDbConnection db = new MySqlConnection(GetConnection()))
            {
                var recipe = db.Query<Recipe>("Select * From Recipes").ToList();
                return recipe;
            }
        }

        public static bool Save(Recipe data)
        {
            string sql = @"INSERT INTO recipes (id, name, dateAdded, author) 
            Values (?Id, ?Name, ?DateAdded, ?Author);";
            using (IDbConnection db = new MySqlConnection(GetConnection()))
            {
                Console.WriteLine(data.Name);
                var result = db.Execute(sql, data);

                if (result > 0) {
                    return true;
                }
            }
            return false;

        }

        public static bool Delete(string id)
        {
            return false;
            
        }
    }
}