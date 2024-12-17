using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMVC.Models
{
    public class UserRole
    {
        public int Id { get; set; } // Primary Key

        public int UserId { get; set; } // Foreign Key
        public string Role { get; set; }
    }
}