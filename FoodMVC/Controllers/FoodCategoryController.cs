using FoodMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FoodMVC.Controllers
{
    public class FoodCategoryController : Controller
    {
        private readonly HttpClient _client;

        public FoodCategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44321/");
        }

        public async Task<ActionResult> Index(int restaurantId)
        {
            // API URL with restaurantId as parameter
            var response = await _client.GetStringAsync($"api/FoodCategory/{restaurantId}");

            // Deserialize response to List<FoodCategory>
            var categories = JsonConvert.DeserializeObject<List<FoodCategory>>(response);

            // Pass the categories to the view
            ViewBag.RestaurantId = restaurantId;
            return View(categories);
        }
    }
}