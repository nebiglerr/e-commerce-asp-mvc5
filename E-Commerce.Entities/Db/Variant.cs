using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public class Variant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Definition { get; set; }
        public Nullable<int> CategoriesId { get; set; }

        public virtual Category Categories { get; set; }
        public virtual List<OrderDetail> OrderDetail { get; set; }
        public virtual List<ProductVariant> ProductVariants { get; set; }
        public Variant()
        {
            OrderDetail = new List<OrderDetail>();
            ProductVariants = new List<ProductVariant>();
        }
    }
}
