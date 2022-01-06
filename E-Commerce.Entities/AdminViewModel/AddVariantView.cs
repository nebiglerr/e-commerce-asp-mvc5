using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.AdminViewModel
{
    public class AddVariantView
    {
        public int Id { get; set; }
        [DisplayName("Variant Ekle"),
         Required(ErrorMessage = "{0} alanını giriniz"),
         StringLength(50, ErrorMessage = "{0} alanı max {1} olmalıdır.")]
        public string Definition { get; set; }
    }
}
