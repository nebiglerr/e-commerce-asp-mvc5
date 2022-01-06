using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace E_Commerce.Entities.Db
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string StockCode { get; set; }
        public int Piece { get; set; }
        public DateTime AddDate { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Nullable<int> LowerCategoryId { get; set; }

        [ForeignKey("DeliveryInformation")]
        public Nullable<int>  DeliveryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual DeliveryInformation DeliveryInformation { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual List<ProductVariant> ProductVariants { get; set; }

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

        public Product()
        {
            Comments = new List<Comments>();
            OrderDetails = new List<OrderDetail>();
            ProductVariants = new List<ProductVariant>();
        }

    }
}
