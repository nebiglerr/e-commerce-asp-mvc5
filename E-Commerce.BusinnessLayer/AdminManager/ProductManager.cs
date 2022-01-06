using E_Commerce.BusinnessLayer.Abstract;
using E_Commerce.BusinnessLayer.Result;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.AdminViewModel;
using E_Commerce.Entities.Db;
using E_Commerce.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.BusinnessLayer.AdminManager
{
    public class ProductManager : ManagerBase<Product>
    {
        private DatabaseContext _context = new DatabaseContext();
        public List<Product> GetProductList()
        {

            return _context.Products.ToList();
        }
        public List<PropertList> GetPropertytList()
        {

            return _context.Properties.Include("Categories").Select(x => new PropertList
            {
                Id = x.Id,
                CategoryId = (int)x.CategoryId,
                CategoryName = x.Category.Definition,
                Definition = x.Definition

            }).ToList();
        }
        public List<Property> GetListPropertyt()
        {

            return _context.Properties.ToList();
        }
        public Product GetProductSelected(int id)
        {

            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
        }
        public BusiessLayerResult<Product> ProductAdd(ProductAddViews productAddViews, ProductVariant producsVariantViews)
        {
            BusiessLayerResult<Product> res = new BusiessLayerResult<Product>();
            //var result =  _context.Categories.Where(x => x.Definition == categoryAddViewManager.Definition).Select(x => x.Definition).ToList();

            res.Result = Find(x => x.Name == productAddViews.Name);
            if (res.Result == null)
            {

                _context.Products.Add(new Product()
                {
                    Image = productAddViews.Image,
                    Name = productAddViews.Name,
                    Description = productAddViews.Description,
                    Piece = productAddViews.Piece,
                    Price = productAddViews.Price,
                    StockCode = productAddViews.StockCode,
                    CategoryId = productAddViews.CategoryId,
                    AddDate = DateTime.Now,
                    LowerCategoryId = productAddViews.LowerCategoryId != 0 ? productAddViews.LowerCategoryId : 0



                });
                if (productAddViews.ProducsVariantViews != null)
                {
                    foreach (var item in productAddViews.ProducsVariantViews)
                    {

                        _context.ProductVariants.Add(item);

                    }
                }

                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir Ürün adı mevcut");
            }

            return res;
        }
        public BusiessLayerResult<Product> ProductUpdate(ProductAddViews productAddViews)
        {
            BusiessLayerResult<Product> res = new BusiessLayerResult<Product>();
            //var result =  _context.Categories.Where(x => x.Definition == categoryAddViewManager.Definition).Select(x => x.Definition).ToList();


            var upd = _context.Products.Where(x => x.Id == productAddViews.Id).FirstOrDefault();

            if (productAddViews.Image != null)
            {
                upd.Image = productAddViews.Image;

            }

            //TODO: Burayı Kontrol ET
            if (productAddViews.CategoryId != -1)
            {
                upd.Name = productAddViews.Name;
                upd.Description = productAddViews.Description;
                upd.Piece = productAddViews.Piece;
                upd.Price = productAddViews.Price;
                upd.CategoryId = productAddViews.CategoryId;
                upd.StockCode = productAddViews.StockCode;
            }
            else
            {
                upd.Name = productAddViews.Name;
                upd.Description = productAddViews.Description;
                upd.Piece = productAddViews.Piece;
                upd.Price = productAddViews.Price;
                upd.StockCode = productAddViews.StockCode;
            }
         


            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<Product> ProductDel(int id)
        {
            BusiessLayerResult<Product> res = new BusiessLayerResult<Product>();
            //var result =  _context.Categories.Where(x => x.Definition == categoryAddViewManager.Definition).Select(x => x.Definition).ToList();


            var result = _context.Products.Find(id);

            _context.Products.Remove(result);

            _context.SaveChanges();



            return res;
        }
        public BusiessLayerResult<Property> PropertyAdd(PropertList propertList)
        {
            BusiessLayerResult<Property> res = new BusiessLayerResult<Property>();
            //var result =  _context.Categories.Where(x => x.Definition == categoryAddViewManager.Definition).Select(x => x.Definition).ToList();

           /* res.Result = _context.Properties.Where(x => x.Definition == propertList.Definition).FirstOrDefault();
            if (res.Result == null)
            {*/
                var result = _context.Properties.Add(new Property()
                {


                    Definition = propertList.Definition,
                    CategoryId = propertList.CategoryId,

                });


                _context.SaveChanges();
           // }
           /* else
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir Özellik mevcut");
            }*/




            return res;
        }
    }
}
