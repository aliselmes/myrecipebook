using Microsoft.AspNetCore.Mvc;

namespace recipe_tracker.Controllers {
    public class RecipeController:Controller {
        public ActionResult Index () {
            return Content ("myfirstsite");
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