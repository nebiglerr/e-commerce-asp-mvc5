using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace E_Commerce.Entities.Db
{
    public class ProductVariant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        [ForeignKey("Variant")]
        public int VariantId { get; set; }
        public int Quantity { get; set; }
       [ForeignKey("Property")]
        public int PropertiesId { get; set; }




        public virtual Property Property { get; set; }
        public virtual Variant Variant { get; set; }
        public virtual Product Products { get; set; }
    }
}
