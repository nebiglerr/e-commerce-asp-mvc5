using E_Commerce.AdminApp.Models;
using E_Commerce.BusinnessLayer.AdminManager;
using E_Commerce.Entities.AdminViewModel;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.AdminApp.Controllers
{

    [UseAuthorize]
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly VariantManager _variantManager = new VariantManager();
        // GET: Category
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(CategoryAddView categoryAddView)
        {
            if (!ModelState.IsValid) return View(categoryAddView);
            var res = _categoryManager.CategoryAdd(categoryAddView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(categoryAddView);
            }
            return RedirectToAction("Add");
        }


        public ActionResult Update(int id)
        {
            var val = _categoryManager.GetCategorySelected(id);
            CategoryAddView categoryAddView = new CategoryAddView();
            categoryAddView.Definition = val.Definition;
            return View(categoryAddView);
        }
        [HttpPost]
        public ActionResult Update(CategoryAddView categoryAddView)
        {
            _categoryManager.CategoryUpdate(categoryAddView);
            return RedirectToAction("Add");
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _categoryManager.CategoryDelete(id);
            return RedirectToAction("Add");
        }

        public PartialViewResult GetCategoryPartialList()
        {

            return PartialView(_categoryManager.GetList(false));
        }

        public PartialViewResult CategoryGetDropDown()
        {
            ViewBag.Category = _categoryManager.GetList(false).Select(x => new SelectListItem
            {
                Selected = false,
                Text = x.Definition,
                Value = x.Id.ToString()

            }).ToList();

            return PartialView();
        }
        public PartialViewResult VariantGetDropDown()
        {
            ViewBag.Varyant = _variantManager.GetVariantToList().Select(x => new SelectListItem
            {
                Selected = false,
                Text = x.Definition,
                Value = x.Id.ToString()

            }).ToList();

            return PartialView();
        }
        public ActionResult SubCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SubCategory(SubCategoryAddView subCategoryAddView, int id)
        {

            if (!ModelState.IsValid) return View(subCategoryAddView);
            subCategoryAddView.Id = id;
            var res = _categoryManager.SubCategoryAdd(subCategoryAddView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(subCategoryAddView);
            }
            return RedirectToAction("SubCategory");
        }
        public ActionResult SubDelete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _categoryManager.CategoryDelete(id);
            return RedirectToAction("SubCategory");
        }
        public PartialViewResult GetSubCategoryPartialList()
        {


            return PartialView(_categoryManager.GetList(true));
        }

        public ActionResult AddVariant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVariant(AddVariantView addVariantView, int id)
        {

            if (!ModelState.IsValid) return View(addVariantView);
            addVariantView.Id = id;
            var res = _variantManager.AddVariant(addVariantView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(addVariantView);
            }
            return RedirectToAction("AddVariant");
        }

        public PartialViewResult GetVariantPartialList()
        {


            return PartialView(_variantManager.GetVariantList());
        }


    }
}