using System;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using recipe_tracker.services;
using recipe_tracker.Models.ViewModels;
using recipe_tracker.Models;

namespace recipe_tracker.Controllers
{
    public class RecipeController : Controller
    {
        public ActionResult Index()
        {
            var model = new RecipesViewModel
            {
                Recipes = DatabaseService.GetAll()
            };

            return View(model);
        }

         public ActionResult View(Guid Id)
        {
            var model = new RecipeViewModel
            {
                Recipe = DatabaseService.Get(Id)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit([FromBody]Recipe recipe)
        {
            if (recipe == null)
            {
                return new JsonResult("false");
            }
            
           
            recipe.Id = Guid.NewGuid().ToString();
            recipe.Author = "Merlin";

            var a = DatabaseService.Save(recipe);
            return new JsonResult(a);
        }


    } 
}