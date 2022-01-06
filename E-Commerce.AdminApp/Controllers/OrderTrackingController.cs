using E_Commerce.AdminApp.Models;
using E_Commerce.BusinnessLayer.AdminManager;
using E_Commerce.Entities.AdminViewModel;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.AdminApp.Controllers
{
    [UseAuthorize]
    public class OrderTrackingController : Controller
    {
        private readonly OrderTrackingManager _orderTrackingManager = new OrderTrackingManager();
        public ActionResult CargoCompanyAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CargoCompanyAdd(CargoCompanyAddView cargoCompanyAddView)
        {
            if (!ModelState.IsValid) return View(cargoCompanyAddView);
            var res = _orderTrackingManager.CargoCompanyAdd(cargoCompanyAddView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(cargoCompanyAddView);
            }
            return RedirectToAction("CargoCompanyAdd");
        }

        public PartialViewResult GetCargo()
        {
            return PartialView(_orderTrackingManager.GetCargoCompanyList());
        }

        public ActionResult CargoCompanyUpdate(int id)
        {
            var val = _orderTrackingManager.GetCargoCompanySelected(id);
            CargoCompanyAddView cargoCompanyAddView = new CargoCompanyAddView();
            cargoCompanyAddView.TaxNo = val.TaxNo;
            cargoCompanyAddView.Telefon = val.Telefon;
            cargoCompanyAddView.WebSite = val.WebSite;
            cargoCompanyAddView.EMail = val.EMail;
            cargoCompanyAddView.CompanyName = val.CompanyName;
            cargoCompanyAddView.Adress = val.Adress;
            return View(cargoCompanyAddView);
        }
        [HttpPost]
        public ActionResult CargoCompanyUpdate(CargoCompanyAddView cargoCompanyAddView)
        {
            _orderTrackingManager.CargoCompanyUpdate(cargoCompanyAddView);

            return RedirectToAction("CargoCompanyAdd");
        }

        public ActionResult PaymentMethod()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PaymentMethod(PaymentMethodAddView paymentMethodAddView)
        {
            if (!ModelState.IsValid) return View(paymentMethodAddView);
            var res = _orderTrackingManager.PaymentMethodAdd(paymentMethodAddView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(paymentMethodAddView);
            }
            return RedirectToAction("PaymentMethod");
        }

        public PartialViewResult GetPaymentMethod()
        {
            return PartialView(_orderTrackingManager.GetPaymentMethodsList());
        }
        public ActionResult PaymentMethodUpdate(int id)
        {
            var val = _orderTrackingManager.GetPaymentMethodSelected(id);
            PaymentMethodAddView paymentMethodAddView = new PaymentMethodAddView();
            paymentMethodAddView.Definition = val.Definition;
            paymentMethodAddView.Description = val.Description;
            return View(paymentMethodAddView);
        }
        [HttpPost]
        public ActionResult PaymentMethodUpdate(PaymentMethodAddView paymentMethodAddView)
        {
            var val = _orderTrackingManager.PaymentMethodUpdate(paymentMethodAddView);

            return RedirectToAction("PaymentMethod");
        }

        public ActionResult PaymentMethodDelete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _orderTrackingManager.PaymentMethodDelete(id);
            return RedirectToAction("PaymentMethod");
        }

        public ActionResult Status()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Status(OrderStatusAddView orderStatusAddView)
        {
            if (!ModelState.IsValid) return View(orderStatusAddView);
            var res = _orderTrackingManager.StatusAdd(orderStatusAddView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(orderStatusAddView);
            }
            return RedirectToAction("Status");
        }
        public ActionResult StatusDelete(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            _orderTrackingManager.StatusDelete(id);
            return RedirectToAction("Status");
        }
        public ActionResult StatusUpdate(int id)
        {
            var val = _orderTrackingManager.GetStatusSelected(id);
            OrderStatusAddView orderStatusAddView = new OrderStatusAddView();
            orderStatusAddView.Definition = val.Definition;
            orderStatusAddView.Detail = val.Detail;
            return View(orderStatusAddView);
        }
        [HttpPost]
        public ActionResult StatusUpdate(OrderStatusAddView orderStatusAddView)
        {
            var val = _orderTrackingManager.StatusUpdate(orderStatusAddView);

            return RedirectToAction("Status");
        }

        public PartialViewResult GetStatus()
        {
            return PartialView(_orderTrackingManager.GetStatusList());
        }
        public ActionResult OrderList()
        {
            return View(_orderTrackingManager.GetOrders());
        }
        public ActionResult OrderDetail(int id)
        {
            var selectedDetail = _orderTrackingManager.GetOrderDetailWhere(id);
            var status = _orderTrackingManager
                .GetOrderStatus()
                .Select(x => new SelectListItem {
                Value = x.Id.ToString(),
                Text = x.Definition,
                Selected= false
                }).ToList();
            ViewBag.Status = status;
            return View(selectedDetail);
        }     
        
        [HttpPost]
        public ActionResult OrderDetail(OrderView orderView)
        {
            if (!ModelState.IsValid) return View(orderView);
         var res =   _orderTrackingManager.GetOrderUpdate(orderView);
            if (res.Errors.Count > 0)
            {

                res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(orderView);
            }
            return RedirectToAction("OrderDetail", orderView.Id);
            //return View();
        }

    }
}