﻿using AtuliaRestaurantsCo.Data;
using AtuliaRestaurantsCo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AtuliaRestaurantsCo.Controllers
{
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
    }
}
