using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Entities.WebAppViewModel
{
    public class ChangePasswordView
    {
        public int Id { get; set; }
        [DisplayName("Eski Şifre"),
           Required(ErrorMessage = "{0} alanını giriniz")]
        public string OldPass { get; set; }

        [DisplayName("Yeni Şifre"),
            Required(ErrorMessage = "{0} alanını giriniz"),
         DataType(DataType.Password),
         StringLength(100, ErrorMessage = "{0} alanı en az {2} karakter olmalıdır.", MinimumLength = 6),
         RegularExpression("^((?=.*[a-z])(?=.*[A-Z])(?=.*\\d))(?=.*[!@#$%^&*]).+$", ErrorMessage = "Lütfen harf rakam ve karakter kullanın")]
        public string NewPass { get; set; }
        [DisplayName("Yeni Şifre Tekrar"),
            Required(ErrorMessage = "{0} alanını giriniz"),
         DataType(DataType.Password),
         StringLength(100, ErrorMessage = "{0} alanı en az {2} karakter olmalıdır.", MinimumLength = 6), Compare("NewPass", ErrorMessage = "{0} ile {1} uyuşmuyor")]
        public string ReNewPass { get; set; }
    }
}
