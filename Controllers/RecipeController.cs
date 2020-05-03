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
            var model = new RecipeViewModel
            {
                Recipes = DatabaseService.GetAll()
            };

            return View(model);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit([FromBody]Recipe recipe)
        {
            if (recipe == null)
            {
                return new JsonResult("false");
            }
            try
            {
                Console.WriteLine("Name is '{0}'", recipe.Name);
            }
            catch (Exception e)
            {
            }
            //var recipe = new Recipe
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = name,
            //    DateAdded = DateTime.Now,
            //    Author = "admin"
            //};
            recipe.Id = Guid.NewGuid().ToString();
            recipe.Author = "Merlin";

            var a = DatabaseService.Save(recipe);
            return new JsonResult(a.ToString());
        }
    }
}