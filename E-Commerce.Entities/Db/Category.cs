using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace E_Commerce.Entities.Db
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Definition { get; set; }

        [ForeignKey("CenterCategories")]
        public int? UpperCategoryId { get; set; }

        public string GenerateSlug()
        {
            string phrase = string.Format("{0}-{1}", "c"+Id, Definition);

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

        public virtual List<Category> CenterCategories { get; set; }

        public virtual List<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
            CenterCategories = new List<Category>();
        }
    }
}
