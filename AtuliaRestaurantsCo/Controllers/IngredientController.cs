using AtuliaRestaurantsCo.Data;
using AtuliaRestaurantsCo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AtuliaRestaurantsCo.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        
        private Repository<Ingredient> ingredients;

        public IngredientController(ApplicationDbContext context)
        {
            ingredients =  new Repository<Ingredient>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await ingredients.GetAllAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            return View(await ingredients.GetByIdAsync(id, new QueryOptions<Ingredient>() { Includes= "ProductIngredients.Product"}));
        }
        //Ingredient/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create((Bind('IngredientId","IngredientName")] 
            if(!ModelState.IsValid)
        {
            await ingredients.AddAsync(ingredients);
            return RedirectToAction("Index")
        }
        return View(Ingredient)
    }
}
