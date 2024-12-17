using FoodMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FoodMVC.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly HttpClient _client;

        public RestaurantController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44321/");
        }

        public async Task<ActionResult> Index()
        {
            var response = await _client.GetStringAsync("api/Restaurant");
            var restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(response);
            return View(restaurants);
        }
    }
}