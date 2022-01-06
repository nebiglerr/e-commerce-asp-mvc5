using E_Commerce.BusinnessLayer;
using E_Commerce.BusinnessLayer.WebAppManager;
using E_Commerce.Entities.Db;
using E_Commerce.Entities.WebAppViewModel;
using E_Commerce.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.WebApp.Controllers
{

    public class ProductController : Controller
    {

        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly ProductManager _productManager = new ProductManager();
        private readonly BasketManager _basketManager = new BasketManager();


        [Route("~/{name}")]
        public ActionResult Detail(string name)
        {
            if (Request.RawUrl != null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    return Redirect("/");
                }
                else
                {
                    if (name.Substring(0).Split('-')[0] == name)
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        if (name.Substring(0).Split('-')[0].Contains("c"))
                        {
                            var value = name.Substring(0).Split('-')[0];
                            var asValue = value.Substring(0).Split('c');

                            ViewBag.GetCategoryInProduct = _categoryManager.GetCategoryInProduct(int.Parse(asValue[1]));
                            return View("Category", new { id = asValue[1], name = name.Substring(0).Split('-')[1] });
                            // return RedirectToAction("Category", new { id=asValue[1] , name=name.Substring(0).Split('-')[1] });
                            //  return PartialView("~/Views/Category/_GetCategoryPartial.cshtml");
                        }
                        else
                        {
                            int splitingId = int.Parse(name.Substring(0).Split('-')[0]);
                            if (splitingId == null || splitingId < 1)
                            {
                                return Redirect("/");
                            }
                            var selectedProduct = _productManager.GetProductId(splitingId);
                            ViewBag.ProductVariant = _productManager.GetProductVariant(splitingId);
                            ViewBag.ProductProperty = _productManager.GetProductProperties(splitingId);
                            ViewBag.ProductCategory = _productManager.GetProductCategory(splitingId);
                            ViewBag.RefundConditionsy = _productManager.GetRefundConditionsy();

                            return View(selectedProduct);
                        }

                    }


                }

            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    return Redirect("/");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Detail(OrderDetailView orderDetailView)
        {
            var selectedProduct = _productManager.GetProductId(orderDetailView.Id);
            var selectedVariant = _productManager.GetProductVariantName(orderDetailView.VariantId);
            var selectedProperty = _productManager.GetProductPropertiesName(orderDetailView.PropertyId);
            if (Basket().BasketsOfProductCount(orderDetailView.Id) != null)
            {
                int val = Basket().BasketsOfProductCount(orderDetailView.Id).Quantity;
                if (val >= selectedProduct.Piece)
                {
                    return RedirectToAction("", selectedProduct.GenerateSlug());
                }
                else
                {
                    Basket().BasketAdd(
                   new BasketDetail
                   {

                       Product = selectedProduct,
                       VaryantId = orderDetailView.VariantId,
                       PropertyId = orderDetailView.PropertyId,
                       Property = selectedProperty,
                       Varyant = selectedVariant,
                       Quantity = orderDetailView.Quantity,
                       Count = 1,
                       ProducId = selectedProduct.Id,
                       Kdv = orderDetailView.Kdv,
                       Total = orderDetailView.Total,
                       SellBy = orderDetailView.SellBy,
                       Name = orderDetailView.Name,
                       Price = orderDetailView.Price,
                       UserId = orderDetailView.UserId,
                       PaymentMethodId = orderDetailView.PaymentMethodId,
                       CargoId = orderDetailView.CargoId



                   }, orderDetailView.Id);

                    return View(new { result = 1, JsonRequestBehavior.AllowGet });
                }
            }
            else
            {
                Basket().BasketAdd(
                   new BasketDetail
                   {

                       Product = selectedProduct,
                       VaryantId = orderDetailView.VariantId,
                       PropertyId = orderDetailView.PropertyId,
                       Property = selectedProperty,
                       Varyant = selectedVariant,
                       Quantity = orderDetailView.Quantity,
                       Count = 1,
                       ProducId = selectedProduct.Id,
                       Kdv = orderDetailView.Kdv,
                       Total = orderDetailView.Total,
                       SellBy = orderDetailView.SellBy,
                       Name = orderDetailView.Name,
                       Price = orderDetailView.Price,
                       UserId = orderDetailView.UserId,
                       PaymentMethodId = orderDetailView.PaymentMethodId,
                       CargoId = orderDetailView.CargoId


                   }, orderDetailView.Id);
                //  Basket();
                return Json(new { result = 1, JsonRequestBehavior.AllowGet });

            }


        }
        //TODO: ANASAYFADAKİ SEPETE EKLE BUTONU PASİFE ALINDI
        [HttpPost]
        public ActionResult BasketAdd(OrderDetailView orderDetailView)
        {
            var selectedProduct = _productManager.GetProductId(orderDetailView.Id);
            var selectedVariant = _productManager.GetProductVariantName(orderDetailView.VariantId);
            var selectedProperty = _productManager.GetProductPropertiesName(orderDetailView.PropertyId);
            if (Basket().BasketsOfProductCount(orderDetailView.Id) != null)
            {
                int val = Basket().BasketsOfProductCount(orderDetailView.Id).Quantity;
                if (val >= selectedProduct.Piece)
                {
                    return RedirectToAction("", selectedProduct.GenerateSlug());
                }
                else
                {
                    Basket().BasketAdd(
                   new BasketDetail
                   {

                       Product = selectedProduct,
                       VaryantId = orderDetailView.VariantId,
                       PropertyId = orderDetailView.PropertyId,
                       Property = selectedProperty,
                       Varyant = selectedVariant,
                       Quantity = orderDetailView.Quantity,
                       Count = 1,
                       ProducId = selectedProduct.Id



                   }, orderDetailView.Id);
                    return RedirectToAction("");
                }
            }
            else
            {
                Basket().BasketAdd(
                   new BasketDetail
                   {

                       Product = selectedProduct,
                       VaryantId = orderDetailView.VariantId,
                       PropertyId = orderDetailView.PropertyId,
                       Property = selectedProperty,
                       Varyant = selectedVariant,
                       Quantity = orderDetailView.Quantity,
                       Count = 1,
                       ProducId = selectedProduct.Id



                   }, orderDetailView.Id);
                ViewBag.Val = "Soktum";
                //  Basket();
                return RedirectToAction("");

            }

        }

        [HttpGet]
        public ActionResult Category(int id, string name)
        {
            return View();
        }


        public UserBasket Basket()
        {
            var list = (UserBasket)Session["basket"];
            if (list == null)
            {
                if (ManagerSession.User != null)
                {

                    list = new UserBasket();
                    list.User = ManagerSession.User as User;
                    Session["basket"] = list;
                }
                else
                {
                    list = new UserBasket();
                    Session["basket"] = list;
                }



            }


            return list;
        }

        [Route("~/mybasket")]
        [HttpGet]
        public ActionResult MyBasket()
        {
           /* if (Session["basket"] == null)
            {
                var list = (UserBasket)Session["basket"];
                if (list == null)
                {
                    if (ManagerSession.User != null)
                    {

                        list = (UserBasket)Session["basket"];
                        list.User = ManagerSession.User as User;
                        Session["basket"] = list;
                        //return View(list);
                    }
                    else
                    {
                        list = (UserBasket)Session["basket"];
                        Session["basket"] = list;
                        // return View(list);
                    }



                }

            }*/

            return View(Basket());
        }

        [UseAuthorize]
        [Route("~/mybasket/paymentprocess/{id}")]
        [HttpGet]
        public ActionResult PaymentProcess(string id)
        {
            int splitingId = int.Parse(id.Substring(0).Split('-')[0]);
            var user = _basketManager.GetId(splitingId);
            ViewBag.Paymemtnt = _basketManager.GetPayment();
            ViewBag.CargoCompany = _basketManager.GetCargoCompany();
            TempData["BillingAddress"] = user.BillingAddress;
            TempData["UserId"] = splitingId;

            return View(Basket());
        }

        [HttpPost]
        public ActionResult PaymentProcess()
        {
            //TODO: SIÇTIK
            var basket = (UserBasket)Session["basket"];

            foreach (var item in basket.BasketDetail)
            {

                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ProductId = item.ProducId;
                orderDetail.Quantity = item.Quantity;
                orderDetail.VariantId = item.VaryantId;
                orderDetail.PaymentMethodId = item.PaymentMethodId;
                orderDetail.Price = item.Price;
                orderDetail.Total = item.Total;
                orderDetail.Kdv = item.Kdv;
                orderDetail.CargoId = item.CargoId;
                orderDetail.Name = item.Name;
                orderDetail.PropertyId = item.PropertyId;
                Order order = new Order();
                order.SellBy = item.SellBy;
                order.UserId = basket.User.Id;
                order.OrderStatusId = 4;

                _basketManager.AddOrder(order, orderDetail);

            }

            Session["basket"] = null;
            return Redirect("/");
        }



        [Route("~/paymentprocess/billing")]
        [HttpGet]
        public ActionResult BillingAddress()
        {
            if (ManagerSession.User == null)
            {
                return RedirectToAction("Register", "Login");
            }
            return View(Basket());
        }
        [Route("~/mybasket/basketdelete")]
        public ActionResult BasketDelete(int ProductId, string Varyant)
        {
            BasketDetail deleteProduct = Basket().BasketDetail.Where(x => x.Product.Id == ProductId && x.Varyant == Varyant).FirstOrDefault();
            Basket().Del(deleteProduct);
            return Redirect("~/mybasket");
        }
    }
}