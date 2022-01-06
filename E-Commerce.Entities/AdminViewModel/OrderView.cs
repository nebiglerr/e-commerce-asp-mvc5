using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
    public class OrderView
    {
        public int Id { get; set; }
        public DateTime SellBy { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public string CargoFollow { get; set; }
        public int BasketId { get; set; }
    }
}
