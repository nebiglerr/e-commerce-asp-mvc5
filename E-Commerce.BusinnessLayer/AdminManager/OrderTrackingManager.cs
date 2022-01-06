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
using System.Web.Mvc;

namespace E_Commerce.BusinnessLayer.AdminManager
{
    public class OrderTrackingManager
    {
        private DatabaseContext _context = new DatabaseContext();

        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
        public Order GetOrderDetailWhere(int id)
        {
            return _context.Orders.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<OrderStatus> GetOrderStatus()
        {
            return _context.OrderStatuses.ToList();
        }
        public List<CargoCompany> GetCargoCompanyList()
        {

            return _context.CargoCompanies.ToList();
        }
        public List<PaymentMethod> GetPaymentMethodsList()
        {

            return _context.PaymentMethods.ToList();
        }
        public List<OrderStatus> GetStatusList()
        {

            return _context.OrderStatuses.ToList();
        }
        public CargoCompany GetCargoCompanySelected(int id)
        {


            return _context.CargoCompanies.Where(x => x.Id == id).FirstOrDefault();
        }
        public PaymentMethod GetPaymentMethodSelected(int id)
        {


            return _context.PaymentMethods.Where(x => x.Id == id).FirstOrDefault();
        }
        public OrderStatus GetStatusSelected(int id)
        {


            return _context.OrderStatuses.Where(x => x.Id == id).FirstOrDefault();
        }
        public BusiessLayerResult<PaymentMethod> PaymentMethodDelete(int id)
        {
            BusiessLayerResult<PaymentMethod> res = new BusiessLayerResult<PaymentMethod>();

            var result = _context.PaymentMethods.Find(id);
            _context.PaymentMethods.Remove(result);

            _context.SaveChanges();


            return res;
        }
        public BusiessLayerResult<CargoCompany> CargoCompanyAdd(CargoCompanyAddView cargoCompanyAddView)
        {
            BusiessLayerResult<CargoCompany> res = new BusiessLayerResult<CargoCompany>();
            res.Result = _context.CargoCompanies.Where(x => x.CompanyName == cargoCompanyAddView.CompanyName).FirstOrDefault();
            if (res.Result == null)
            {
                _context.CargoCompanies.Add(new CargoCompany()
                {
                    CompanyName = cargoCompanyAddView.CompanyName,
                    Adress = cargoCompanyAddView.Adress,
                    EMail = cargoCompanyAddView.EMail,
                    TaxNo = cargoCompanyAddView.TaxNo,
                    Telefon = cargoCompanyAddView.Telefon,
                    WebSite = cargoCompanyAddView.WebSite

                });
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir Şirket  adı mevcut");
            }




            return res;
        }
        public BusiessLayerResult<CargoCompany> CargoCompanyUpdate(CargoCompanyAddView cargoCompanyAddView)
        {
            BusiessLayerResult<CargoCompany> res = new BusiessLayerResult<CargoCompany>();
            var result = _context.CargoCompanies.Where(x => x.Id == cargoCompanyAddView.Id).FirstOrDefault();

            result.TaxNo = cargoCompanyAddView.TaxNo;
            result.Telefon = cargoCompanyAddView.Telefon;
            result.Adress = cargoCompanyAddView.Adress;
            result.CompanyName = cargoCompanyAddView.CompanyName;
            result.EMail = cargoCompanyAddView.EMail;
            result.WebSite = cargoCompanyAddView.WebSite;
            _context.SaveChanges();
            return res;
        }

        public BusiessLayerResult<PaymentMethod> PaymentMethodAdd(PaymentMethodAddView paymentMethodAddView)
        {
            BusiessLayerResult<PaymentMethod> res = new BusiessLayerResult<PaymentMethod>();
            res.Result = _context.PaymentMethods.Where(x => x.Definition == paymentMethodAddView.Definition).FirstOrDefault();
            if (res.Result == null)
            {
                _context.PaymentMethods.Add(new PaymentMethod()
                {
                    Definition = paymentMethodAddView.Definition,
                    Description = paymentMethodAddView.Description,

                });
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir Ödeme Yöntem Şekli Mevcut");
            }




            return res;
        }
        public BusiessLayerResult<PaymentMethod> PaymentMethodUpdate(PaymentMethodAddView paymentMethodAddView)
        {
            BusiessLayerResult<PaymentMethod> res = new BusiessLayerResult<PaymentMethod>();
            var result = _context.PaymentMethods.Where(x => x.Id == paymentMethodAddView.Id).FirstOrDefault();

            result.Definition = paymentMethodAddView.Definition;
            result.Description = paymentMethodAddView.Description;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<OrderStatus> StatusAdd(OrderStatusAddView orderStatusAddView)
        {
            BusiessLayerResult<OrderStatus> res = new BusiessLayerResult<OrderStatus>();
            res.Result = _context.OrderStatuses.Where(x => x.Definition == orderStatusAddView.Definition).FirstOrDefault();
            if (res.Result == null)
            {
                _context.OrderStatuses.Add(new OrderStatus()
                {
                    Definition = orderStatusAddView.Definition,
                    Detail = orderStatusAddView.Detail,

                });
                _context.SaveChanges();
            }
            else if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Böyle bir Durum Mevcut");
            }




            return res;
        }

        public BusiessLayerResult<OrderStatus> StatusDelete(int id)
        {
            BusiessLayerResult<OrderStatus> res = new BusiessLayerResult<OrderStatus>();

            var result = _context.OrderStatuses.Find(id);
            _context.OrderStatuses.Remove(result);

            _context.SaveChanges();


            return res;
        }
        public BusiessLayerResult<OrderStatus> StatusUpdate(OrderStatusAddView orderStatusAddView)
        {
            BusiessLayerResult<OrderStatus> res = new BusiessLayerResult<OrderStatus>();
            var result = _context.OrderStatuses.Where(x => x.Id == orderStatusAddView.Id).FirstOrDefault();

            result.Definition = orderStatusAddView.Definition;
            result.Detail = orderStatusAddView.Detail;
            _context.SaveChanges();

            return res;
        }
        public BusiessLayerResult<Order> GetOrderUpdate(OrderView orderView)
        {
            BusiessLayerResult<Order> res = new BusiessLayerResult<Order>();
            var result = _context.Orders.Where(x => x.Id == orderView.Id).FirstOrDefault();
            result.OrderStatusId = orderView.OrderStatusId;
            _context.SaveChanges();
            return res;
        }
    }
}
