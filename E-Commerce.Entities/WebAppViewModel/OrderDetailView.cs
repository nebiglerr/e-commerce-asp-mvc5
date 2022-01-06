using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.WebAppViewModel
{
    public class OrderDetailView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProducId { get; set; }
        public int Quantity { get; set; }
        public int Kdv { get; set; }
        public decimal Price { get; set; }
        public int Total { get; set; }

        public string Name { get; set; }
        public string Property { get; set; }
        public int PropertyId { get; set; }
        public int VariantId { get; set; }
        public int Count { get; set; }
        public int PaymentMethodId { get; set; }
        public int CargoId { get; set; }
        public DateTime SellBy { get; set; }

    }
}
