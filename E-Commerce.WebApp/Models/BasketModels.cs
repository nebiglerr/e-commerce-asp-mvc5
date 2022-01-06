using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.WebApp.Models
{
    public class BasketModels
    {
       // public User User { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}