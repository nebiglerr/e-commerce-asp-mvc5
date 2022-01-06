using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
    public class ProductAddViews
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public int Piece { get; set; }
        public DateTime AddDate { get; set; }
        [DisplayName("Kategori"),
          Required(ErrorMessage = "{0} alanını giriniz"),]
        public int CategoryId { get; set; }
        [DisplayName("Alt Kategori"),
    Required(ErrorMessage = "{0} alanını giriniz"),]
        public int LowerCategoryId { get; set; }
        public int PropertiesId { get; set; }

        public virtual List<ProductVariant> ProducsVariantViews { get; set; }
    }
}
