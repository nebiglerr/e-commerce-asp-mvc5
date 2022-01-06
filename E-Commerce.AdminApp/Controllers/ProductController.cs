using E_Commerce.AdminApp.Models;
using E_Commerce.BusinnessLayer.AdminManager;
using E_Commerce.Entities.AdminViewModel;
using E_Commerce.Entities.Db;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace E_Commerce.AdminApp.Controllers
{
    [UseAuthorize]
    public class ProductController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly VariantManager _variantManager = new VariantManager();
        private readonly ProductManager _productManager = new ProductManager();
        public ActionResult Add()
        {
            ViewBag.Category = _categoryManager.GetList(false);
            ViewBag.Varyant = _variantManager.GetVariantList();
            ViewBag.ListPropertyt = _productManager.GetListPropertyt();
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductAddViews productAddViews, ProductVariant producsVariantViews)
        {
            if (!ModelState.IsValid) return View(productAddViews);
            var res = _productManager.ProductAdd(productAddViews, producsVariantViews);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(productAddViews);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        public JsonResult ImageUpload()
        {
            if (Request.Files.Count > 0)
            {
                try
                {
                    string resimler = "";
                    HttpFileCollectionBase httpFileCollectionBase = Request.Files;
                    for (int i = 0; i < httpFileCollectionBase.Count; i++)
                    {
                        HttpPostedFileBase httpPostedFileBase = httpFileCollectionBase[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testFile = httpPostedFileBase.FileName.Split(new char[] { '\\' });
                            fname = testFile[testFile.Length - 1];
                        }
                        else
                        {
                            fname = httpPostedFileBase.FileName;
                        }
                        fname = Guid.NewGuid() + fname;
                        resimler += fname + ";";

                        httpPostedFileBase.SaveAs(Server.MapPath(Path.Combine("~/Content/images", fname))); ;
                    }
                    return Json(resimler);

                }
                catch (Exception ex)
                {

                    return Json("Resim yüklenirken hata oluştu :" + ex.Message);
                }
            }
            return Json("Dosya Seçilmedi");

        }
        [HttpPost]
        public ActionResult VaryantGet(int CategoryId)
        {
            var liste = _variantManager.GetVariantList().Where(x => x.CategoriesId == CategoryId).Select(x => new
            {
                x.Id,
                x.Definition,
                x.CategoriesId
            }).ToList();

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            string result = javaScriptSerializer.Serialize(liste);

            return Json(result, JsonRequestBehavior.AllowGet);
        }    
        [HttpPost]
        public ActionResult SubCategory(int CategoryId)
        {
            var liste = _categoryManager.SubCategory(CategoryId);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();

            string result = javaScriptSerializer.Serialize(liste);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetProductPartialList()
        {

            return PartialView(_productManager.GetProductList());
        }

        public ActionResult Stok()
        {
            return View(_productManager.GetProductList());
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _productManager.ProductDel(id);
            return RedirectToAction("Add");
        }
        public ActionResult Update(int id)
        {
            ViewBag.Category = _categoryManager.GetList(false);
            ViewBag.Varyant = _variantManager.GetVariantList();
            var product = _productManager.GetProductSelected(id);
            ProductAddViews productAddViews = new ProductAddViews();
            productAddViews.Id = id;
            productAddViews.AddDate = product.AddDate;
            productAddViews.CategoryId = product.CategoryId;
            productAddViews.Description = product.Description;
            productAddViews.Image = product.Image;
            productAddViews.Name = product.Name;
            productAddViews.StockCode = product.StockCode;
            productAddViews.Piece = product.Piece;
            productAddViews.Price = product.Price;
            return View(productAddViews);
        }
        [HttpPost]
        public ActionResult Update(ProductAddViews productAddViews, ProductVariant producsVariantViews)
        {
            if (Request.Files.Count > 0)
            {
                string images = "";
                HttpFileCollectionBase httpFileCollectionBase = Request.Files;
                HttpPostedFileBase httpPostedFileBase = httpFileCollectionBase[0];
                string fname;
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testFile = httpPostedFileBase.FileName.Split(new char[] { '\\' });
                    fname = testFile[testFile.Length - 1];
                }
                else
                {
                    fname = httpPostedFileBase.FileName;
                }

                fname = Guid.NewGuid() + fname;
                images += fname + ";";

                httpPostedFileBase.SaveAs(Server.MapPath(Path.Combine("~/Content/images", fname))); ;
                productAddViews.Image = images;
                _productManager.ProductUpdate(productAddViews);
            }
            else
            {
                _productManager.ProductUpdate(productAddViews);
            }
            return RedirectToAction("Add");
        }


        public ActionResult PropertyAdd()
        {
            ViewBag.Category = _categoryManager.GetList(false);
            return View();
        }
        [HttpPost]
        public ActionResult PropertyAdd(PropertList propertList)
        {
            if (!ModelState.IsValid) return View(propertList);
            var res = _productManager.PropertyAdd(propertList);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(propertList);
            }

            return RedirectToAction("PropertyAdd");
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

        public PartialViewResult GetPropertyList()
        {
            return PartialView(_productManager.GetPropertytList());
        }

    }
}