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

namespace E_Commerce.BusinnessLayer.AdminManager
{
    public class CategoryManager : ManagerBase<Category>
    {
        private DatabaseContext _context = new DatabaseContext();


        public List<Category> GetList(bool isUpper)
        {

            if (isUpper)
            {
                return _context.Categories.Where(x => x.UpperCategoryId != null).ToList();
            }
            return _context.Categories.Where(x => x.UpperCategoryId == null).ToList();
        } 
        public List<Category> SubCategory(int upperCategoryId)
        {

            
            return _context.Categories.Where(x => x.UpperCategoryId == upperCategoryId).ToList();
        }
        public Category GetCategorySelected(int id)
        {


            return _context.Categories.Where(x => x.Id == id).FirstOrDefault();
        }


        public BusiessLayerResult<Category> CategoryDelete(int id)
        {
            BusiessLayerResult<Category> res = new BusiessLayerResult<Category>();

            var result = _context.Categories.Find(id);
            _context.Categories.Remove(result);

            _context.SaveChanges();


            return res;
        }
        public BusiessLayerResult<Category> CategoryUpdate(CategoryAddView categoryAddViewManager)
        {
            BusiessLayerResult<Category> res = new BusiessLayerResult<Category>();

            var upd = _context.Categories.Where(x => x.Id == categoryAddViewManager.Id).FirstOrDefault();
            upd.Definition = categoryAddViewManager.Definition;

            _context.SaveChanges();


            return res;
        }
        public BusiessLayerResult<Category> CategoryAdd(CategoryAddView categoryAddViewManager)
        {
            BusiessLayerResult<Category> res = new BusiessLayerResult<Category>();

            res.Result = Find(x => x.Definition == categoryAddViewManager.Definition);
            if (res.Result == null)
            {

                _context.Categories.Add(new Category()
                {

                    Definition = categoryAddViewManager.Definition,

                });
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir kategori adı mevcut");
            }

            return res;
        }
        public BusiessLayerResult<Category> SubCategoryAdd(SubCategoryAddView subCategoryAddViewManager)
        {
            BusiessLayerResult<Category> res = new BusiessLayerResult<Category>();

            res.Result = Find(x => x.Definition == subCategoryAddViewManager.Definition);
            if (res.Result == null)
            {

                _context.Categories.Add(new Category()
                {

                    Definition = subCategoryAddViewManager.Definition,
                    UpperCategoryId = subCategoryAddViewManager.Id

                }); ;
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir kategori adı mevcut");
            }

            return res;
        }
    }
}
