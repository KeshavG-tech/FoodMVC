﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMVC.Models
{
    public class Order
    {
        public int Id { get; set; } 

        public int UserId { get; set; } 

        public DateTime OrderDate { get; set; }
    }
}