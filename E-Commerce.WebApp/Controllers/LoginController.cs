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

    public class LoginController : Controller
    {
        private readonly LoginManager _loginManager = new LoginManager();
        private readonly BasketManager _basketManager = new BasketManager();
        public ActionResult Loreg()
        {
            Session.Clear();
            return View();
        }
        [HttpPost]
        public ActionResult Loreg(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return RedirectToAction("Loreg");
            var res = _loginManager.Login(loginViewModel);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return RedirectToAction("Loreg");
            }

            var list = (UserBasket)Session["basket"];
            list = new UserBasket();
            list.User = ManagerSession.User as User;
            Session["basket"] = list;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            var res = _loginManager.Register(registerViewModel);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(registerViewModel);
            }
            return RedirectToAction("Account");
        }
        [UseAuthorize]
        public ActionResult Account()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Account(UserViewModel UserViewModel)
        {

            if (!ModelState.IsValid) return View(UserViewModel);

            var res = _loginManager.AccountUpdate(UserViewModel);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(UserViewModel);
            }


            return View();
        }
        [UseAuthorize]
        public ActionResult PassChange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PassChange(ChangePasswordView changePasswordView)
        {
            if (!ModelState.IsValid) return View(changePasswordView);
            var res = _loginManager.PassUpdate(changePasswordView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(changePasswordView);
            }
            return View();
        }
        [UseAuthorize]
        public ActionResult OrderHistory()
        {
            var user = ManagerSession.User as User;
            // List<Order> ordering = _basketManager.GetOrder(user.Id);
            ViewBag.GetOrder = _basketManager.GetOrder(user.Id);
            if (ViewBag.GetOrder.Count > 0)
            {
                ViewBag.GetOrderDetail = _basketManager.GetOrderDetail(user.Id);
                foreach (var item in ViewBag.GetOrder)
                {
                    if (item.UserId == user.Id)
                    {
                          ViewBag.GetOrderStatus = _basketManager.GetOrderStatus(item.OrderStatusId);
                    }
                  
                }
               
            }
            
            //  ordering.Where(x => x.OrderDetailId == x.OrderDetail.Id && x.OrderDetailId == x.OrderDetail.UpperOrderDetailId && x.OrderDetail.UpperOrderDetailId == null).ToList();
            return View();
        }
        [UseAuthorize]
        public ActionResult Out()
        {
            ManagerSession.Clear();
            Session.Clear();
            return Redirect("/");
        }
    }
}