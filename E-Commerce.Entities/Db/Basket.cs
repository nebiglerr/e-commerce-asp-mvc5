using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
    public class Basket
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Variant")]
        public int VariantId { get; set; }
        public int Quantity { get; set; }
        public int UserId { get; set; }
        [ForeignKey("CenterBasket")]
        public int? UpperBasketId { get; set; }

        public virtual Basket CenterBasket { get; set; }
        public virtual Product Product { get; set; }
        public virtual Variant Variant { get; set; }
        public Basket()
        {
        }
    }
}
