using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
    public class OrderHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Definition { get; set; }
        public string Detail { get; set; }

        public virtual List<User> User { get; set; }
        public OrderHistory()
        {
            User = new List<User>();
        }
    }
}
