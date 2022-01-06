using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.WebAppViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        /*[DisplayName("Adı"),
          Required(ErrorMessage = "{0} alanını giriniz")]*/
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Pass { get; set; }
        public int LoginId { get; set; }
        public int OrderHistoryId { get; set; }
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }

    }
}
