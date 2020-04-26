using System;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using recipe_tracker.services;
using recipe_tracker.Models.ViewModels; 
using recipe_tracker.Models;

namespace recipe_tracker.Controllers {
    public class RecipeController:Controller {
        public ActionResult Index () {
            var model = new RecipeViewModel {
                Recipes = DatabaseService.GetAll()
            };

            return View (model);
        }
        public ActionResult Add () {
            return View ();
        }
        [HttpPost]
        public ActionResult Submit ([FromBody]Recipe recipe) {
            Console.WriteLine(recipe.Name);
            /*var recipe = new Recipe {
                Id = Guid.NewGuid().ToString(),
                Name = recipename,
                DateAdded = DateTime.Now,
                Author = "admin"
            };*/
            recipe.Id = Guid.NewGuid().ToString();
            recipe.Name = "toast";
            var a = DatabaseService.Save(recipe);
            return Content(a.ToString());
        }
    }
} 