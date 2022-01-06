using E_Commerce.BusinnessLayer.Abstract;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.Db;
using E_Commerce.Entities.WebAppViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.WebAppManager
{
   public class ProductManager : ManagerBase<Product>
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<Product> GetProduct()
        {


            return _context.Products.ToList();
        }  
        public Product GetProductId(int id)
        {


            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }  
        public List<ProductVariantList> GetProductVariant(int ProductId)
        {


            return _context.ProductVariants.Where(x => x.ProductId == ProductId).Select( x => new ProductVariantList { 
            
                Id = x.Variant.Id,
                Variant = x.Variant.Definition,
                Quantity = x.Quantity

            }).ToList();
        }
        public string GetProductVariantName(int? VaryantId)
        {
            


            return _context.Variants.FirstOrDefault(b => b.Id == VaryantId).Definition;
        }
        public List<ProductPropertyList> GetProductProperties(int ProductId)
        {


            return _context.ProductVariants.Where(x => x.ProductId == ProductId).Select( x => new ProductPropertyList
            { 
            
                Id = x.Property.Id,
                ProductProperties = x.Property.Definition,
                Quantity = x.Quantity

            }).ToList();
        }
        public string GetProductPropertiesName(int? PropertiesId)
        {



            return _context.Properties.FirstOrDefault(b => b.Id == PropertiesId).Definition;
        }
        public Category GetProductCategory(int ProductId)
        {
            var selectedProduct = _context.Products.Where(x => x.Id == ProductId).FirstOrDefault();

            return _context.Categories.Where(x => x.Id == selectedProduct.CategoryId).FirstOrDefault() ;
        } 
        public RefundConditions GetRefundConditionsy()
        {

            return _context.RefundConditions.FirstOrDefault();
        }
    }
}
