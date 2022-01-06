using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
  public  class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required(AllowEmptyStrings = false)]

        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false)]

        public string Pass { get; set; }

        [ForeignKey("Login")]
        public Nullable<int> LoginId { get; set; } 

        [ForeignKey("Basket")]
        public Nullable<int> BasketId { get; set; }

        [ForeignKey("OrderHistory")]
        public Nullable<int> OrderHistoryId { get; set; }

        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
  



        public virtual Login Login { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual OrderHistory OrderHistory { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public User()
        {
            Orders = new List<Order>();
            Comments = new List<Comments>();
        }



    }
}
