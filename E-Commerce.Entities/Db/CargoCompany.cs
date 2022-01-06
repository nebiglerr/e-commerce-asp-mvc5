using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public  class CargoCompany
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Telefon { get; set; }
        public string WebSite { get; set; }
        public string EMail { get; set; }
        public string TaxNo { get; set; }

        public virtual List<OrderDetail> OrderDetail { get; set; }
        public CargoCompany()
        {
            OrderDetail = new List<OrderDetail>();
        }
    }
}
