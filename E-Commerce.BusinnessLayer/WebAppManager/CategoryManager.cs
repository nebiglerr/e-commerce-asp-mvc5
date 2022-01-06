using E_Commerce.BusinnessLayer.Abstract;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.WebAppManager
{
   public class CategoryManager : ManagerBase<Category>
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<Category> GetCategory()
        {


            return _context.Categories.ToList();
        }
        public List<Product> GetCategoryInProduct(int CategoryId)
        {
            var centerCategory = _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
            if (centerCategory.Count > 0)
            {
                return _context.Products.Where(x => x.CategoryId == CategoryId).ToList();
            }
            else
            {
                return _context.Products.Where(x => x.LowerCategoryId == CategoryId).ToList();
            }

           
        }
    }
}
