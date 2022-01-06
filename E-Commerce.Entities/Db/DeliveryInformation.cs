using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
    public class DeliveryInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Definition { get; set; }
        public string Content { get; set; }
        public virtual List<Product> Products { get; set; }

        public DeliveryInformation()
        {
            Products = new List<Product>();
        }
    }
}
