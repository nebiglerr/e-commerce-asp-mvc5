using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
  public  class Property
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Nullable<int> CategoryId { get; set; }

        public string Definition { get; set; }


        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
        public virtual List<ProductVariant> ProductVariants { get; set; }
        public Property()
        {
            OrderDetail = new List<OrderDetail>();
            ProductVariants = new List<ProductVariant>();
        }
    }
}
