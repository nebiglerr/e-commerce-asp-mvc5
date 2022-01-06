using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public class OrderStatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Definition { get; set; }
        public string Detail { get; set; }

        public virtual List<Order> Orders { get; set; }
        public OrderStatus()
        {
            Orders = new List<Order>();
        }
    }
}
