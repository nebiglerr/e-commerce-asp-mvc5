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
   public class VariantManager : ManagerBase<Variant>
    {
        private DatabaseContext _context = new DatabaseContext();


        public BusiessLayerResult<Variant> AddVariant(AddVariantView addVariantView)
        {
            BusiessLayerResult<Variant> res = new BusiessLayerResult<Variant>();
            //var result =  _context.Categories.Where(x => x.Definition == categoryAddViewManager.Definition).Select(x => x.Definition).ToList();

            res.Result = Find(x => x.Definition == addVariantView.Definition);
            if (res.Result == null)
            {
                Variant variant = new Variant();
                variant.Definition = addVariantView.Definition;
                variant.CategoriesId = addVariantView.Id;
                _context.Variants.Add(variant); 
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir kategori adı mevcut");
            }

            return res;
        }
        public List<VariantList> GetVariantList()
        {

            return _context.Variants.Include("Categories").Select(x => new VariantList
            {

                Id = x.Id,
                Definition = x.Definition,
                CategoryName = x.Categories.Definition,
                CategoriesId = (int)x.CategoriesId
            }).ToList(); ;
        }   
        public List<Variant> GetVariantToList()
        {

            return _context.Variants.Include("Categories").ToList(); ;
        }
    }
}
