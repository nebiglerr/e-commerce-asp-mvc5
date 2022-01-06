using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
  public  class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime SellBy { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("OrderStatus")]
        public int OrderStatusId { get; set; }
        public string CargoFollow { get; set; }
        [ForeignKey("Basket")]
        public Nullable<int> BasketId { get; set; } 
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; } 
        [ForeignKey("OrderDetail")]
        public Nullable<int> OrderDetailId { get; set; }


        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual User User { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual OrderDetail OrderDetail { get; set; }
    }
}
