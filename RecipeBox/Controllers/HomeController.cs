using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;


namespace RecipeBox.Controllers
{
  public class HomeController : Controller
  {
    private readonly RecipeBoxContext _db;

    public HomeController(RecipeBoxContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index(string search)
    {
      List<Recipe> model = _db.Recipes.Where(x => x.RecipeName.Contains(search) || search == null).ToList();
      return View(model);
    }
  }
}