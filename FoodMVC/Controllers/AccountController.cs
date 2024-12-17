using FoodMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FoodMVC.Controllers
{
    public class AccountController : Controller
    {
        HttpClient client = new HttpClient();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:44321/api/User", content);

            if (response.IsSuccessStatusCode)
            {
                FormsAuthentication.SetAuthCookie(user.Name, false);
                return RedirectToAction("Index", "User");
            }
            else
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }

        }

        public ActionResult Signup()
        {

        return View(); 
        }

        [HttpPost]
        public async Task<ActionResult> Signup(User user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:44321/api/User/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    FormsAuthentication.SetAuthCookie(user.Name, false);
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Signup failed. Please try again.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}