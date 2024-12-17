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
using System.Web.UI.WebControls;

namespace FoodMVC.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly HttpClient _client;

        public MenuItemController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44321/");
        }

        public async Task<ActionResult> Index(int restaurantId, int foodCategoryId)
        {
            var response = await _client.GetStringAsync($"api/MenuItem/{restaurantId}/{foodCategoryId}");
            Console.WriteLine(response);

            List<MenuItems> menuItems = JsonConvert.DeserializeObject<List<MenuItems>>(response);

            return View(menuItems);
        }
    }
}