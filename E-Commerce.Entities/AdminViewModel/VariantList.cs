using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
    public class VariantList
    {
        public int Id { get; set; }
        public int CategoriesId { get; set; }

        public string Definition { get; set; }
        public string CategoryName { get; set; }


    }
}
