using FoodMVC.Models;
using FoodMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodMVC.Controllers
{
    public class OrderController : System.Web.Mvc.Controller
    {

        private readonly OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        [System.Web.Mvc.HttpPost]
        public async Task<System.Web.Mvc.ActionResult> PlaceOrder()
        {
            string name = User.Identity.Name;
            int? userId = await GetUserId(name);
            bool isOrderPlaced = await _orderService.PlaceOrder(userId);

            if (isOrderPlaced)
            {
                TempData["Message"] = "Order placed successfully!";
                return RedirectToAction("OrderSuccess");
            }

            TempData["Error"] = "Failed to place order. Try again!";
            return RedirectToAction("OrderFailed");
        }

        private async Task<int?> GetUserId(string name)
        {
             using (var httpClient = new HttpClient())
             {
                 httpClient.BaseAddress = new Uri("https://localhost:44321/");
             
                 var response = await httpClient.GetAsync($"api/User/GetByName?name={name}");
             
                 if (response.IsSuccessStatusCode)
                 {
                     var user = await response.Content.ReadAsAsync<Order>(); 
                     return user?.Id; 
                 }
             }
             
             return null;
        }


        public System.Web.Mvc.ActionResult OrderSuccess()
        {
            return View();
        }

        public System.Web.Mvc.ActionResult OrderFailed()
        {
            return View();
        }
    }
}