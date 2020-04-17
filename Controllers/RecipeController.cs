using Microsoft.AspNetCore.Mvc;
using recipe_tracker.services;
using recipe_tracker.Models.ViewModels; 

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
        public ActionResult Submit (string recipename, string ingredients, string instructions) {
            return Content ("recipename:" + recipename);   
        }
    }
} 