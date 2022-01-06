using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
    public class CargoCompanyAddView
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string Telefon { get; set; }
        public string WebSite { get; set; }
        public string EMail { get; set; }
        public string TaxNo { get; set; }
    }
}
