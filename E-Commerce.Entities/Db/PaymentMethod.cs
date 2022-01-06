using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public class PaymentMethod
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Definition { get; set; }
        public string Description { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
        public PaymentMethod()
        {
            OrderDetail = new List<OrderDetail>();
        }
    }
}
