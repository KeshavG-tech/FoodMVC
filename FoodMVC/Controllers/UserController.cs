using FoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace FoodMVC.Controllers
{
    public class UserController : Controller
    {
        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<User> emp = new List<User>();
            client.BaseAddress = new Uri("https://localhost:44321/api/User");
            var response = client.GetAsync("User");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<User>>();
                display.Wait();
                emp = display.Result;
            }
            return View(emp);
        }

    }
}