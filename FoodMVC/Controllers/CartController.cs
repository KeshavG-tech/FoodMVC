using FoodMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodMVC.Controllers
{
    public class CartController : Controller
    {
        public ActionResult AddToCart(int menuItemId, string name, decimal price)
        {
            // Retrieve the cart from Session
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            // Check if the item already exists in the cart
            var existingItem = cart.FirstOrDefault(x => x.MenuItemId == menuItemId);

            if (existingItem != null)
            {
                // Increment quantity if item already exists
                existingItem.Quantity++;
            }
            else
            {
                // Add new item to the cart
                cart.Add(new CartItem
                {
                    MenuItemId = menuItemId,
                    Name = name,
                    Price = price,
                    Quantity = 1
                });
            }

            // Save the cart back to Session
            Session["Cart"] = cart;

            return RedirectToAction("Cart");
        }

        // View cart items
        public ActionResult Cart()
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();
            return View(cart);
        }

        // Remove item from cart
        public ActionResult RemoveFromCart(int menuItemId)
        {
            var cart = Session["Cart"] as List<CartItem> ?? new List<CartItem>();

            var item = cart.FirstOrDefault(x => x.MenuItemId == menuItemId);
            if (item != null)
            {
                cart.Remove(item);
            }

            Session["Cart"] = cart;

            return RedirectToAction("Cart");
        }
    }

}