using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace E_Commerce.Entities.Db
{
   public class OrderDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime SellBy { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [ForeignKey("Variant")]
        public int VariantId { get; set; }

        public int UserId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Kdv { get; set; }

        public int Total { get; set; }

        public int Quantity { get; set; }
        [ForeignKey("CargoCompany")]
        public int CargoId { get; set; }
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        [ForeignKey("Property")]
        public int PropertyId { get; set; }

        public string GenerateSlug()
        {
            string phrase = string.Format("{0}-{1}", Id, Name);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

        public virtual OrderDetail CenterOrderDetail { get; set; }
        public virtual CargoCompany CargoCompany { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
        public virtual Property Property { get; set; }
        public virtual Variant Variant { get; set; }
        public virtual Product Product { get; set; }
        public virtual List<Order> Orders { get; set; }
        public OrderDetail()
        {
            Orders = new List<Order>();
        }

    }
}
