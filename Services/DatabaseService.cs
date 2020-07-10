using System.Transactions;
using System;
using Dapper;
using recipe_tracker.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Dapper.Transaction;

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
                var recipe = db.Query<Recipe>("Select * From recipes").ToList();
                return recipe;
            }
        }

        public static Recipe Get(Guid Id)
        {
            using (IDbConnection db = new MySqlConnection(GetConnection()))
            {
                var sql = "SELECT * FROM recipes WHERE Id=?Id";
                var recipe = db.QueryFirst<Recipe>(sql, new { Id = Id });
                var ingredientSql = "SELECT * FROM ingredients WHERE recipeId=?Id";
                recipe.Ingredients = db.Query<Ingredient>(ingredientSql, new { Id = Id }).ToList();
                var instructionSql = "SELECT * FROM instructions WHERE recipeId=?Id";
                recipe.Instructions = db.Query<Instruction>(instructionSql, new { Id = Id }).OrderBy(x=>x.Stepnumber).ToList();

                return recipe;
            }
        }

        public static Response Save(Recipe data)
        {
            string sql = @"INSERT INTO recipes (id, name, dateAdded, author)
            Values (?Id, ?Name, ?DateAdded, ?Author);";

            var ingredientSql = @"INSERT INTO ingredients (id, recipeId, name, amount, units)
            Values (?Id, ?RecipeId, ?Name, ?Amount, ?Units);";

            var instructionSql = @"INSERT INTO instructions (id, recipeId, stepnumber, text)
            Values (?Id, ?RecipeId, ?Stepnumber, ?Text);";

            var ingredients = data.Ingredients.ToList();
            ingredients.ForEach(x => x.RecipeId = data.Id);
            var instructions = data.Instructions.ToList();
            instructions.ForEach(x => x.RecipeId = data.Id);
            using (IDbConnection db = new MySqlConnection(GetConnection()))
            {
                Console.WriteLine(data);
                db.Open();
                using (var transaction = db.BeginTransaction())
                {
                    var result = db.Execute(sql, data, transaction: transaction);
                    var ingredientResult = transaction.Execute(ingredientSql, ingredients);
                    var instructionResult = transaction.Execute(instructionSql, instructions);
                    transaction.Commit();
                    if (result > 0)
                    {
                        return new Response { success = true, message = "" };
                    }
                }
            }
            return new Response { success = false };
        }

        public static bool Delete(string id)
        {
            return false;
        }

        public class Response
        {
            public bool success { get; set; }
            public string message { get; set; }
        }
    }
}