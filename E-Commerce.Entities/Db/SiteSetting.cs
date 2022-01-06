using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
   public class SiteSetting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Telefon { get; set; }
        public string WhatsApp { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
    }
}
