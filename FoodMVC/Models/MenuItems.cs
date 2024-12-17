using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMVC.Models
{
    public class MenuItems
    {
        public int Id { get; set; } 

        public int RestaurantId { get; set; } 
        public int FoodCategoryId { get; set; } 

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}