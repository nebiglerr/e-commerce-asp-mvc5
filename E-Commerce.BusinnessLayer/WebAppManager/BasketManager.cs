using E_Commerce.BusinnessLayer.Result;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.WebAppManager
{
    public class BasketManager
    {
        private DatabaseContext _context = new DatabaseContext();
        public User GetId(int id)
        {

            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public List<PaymentMethod> GetPayment()
        {

            return _context.PaymentMethods.OrderByDescending(x => x.Id).ToList();
        }
        public List<CargoCompany> GetCargoCompany()
        {

            return _context.CargoCompanies.OrderByDescending(x => x.Id).ToList();
        }
        public BusiessLayerResult<OrderDetail> AddOrderDetail(OrderDetail orderDetail, Order order)
        {
            BusiessLayerResult<OrderDetail> res = new BusiessLayerResult<OrderDetail>();

            _context.OrderDetails.Add(new OrderDetail
            {
                CargoId = orderDetail.CargoId,
                PaymentMethodId = orderDetail.PaymentMethodId,
                ProductId = orderDetail.ProductId,
                PropertyId = orderDetail.PropertyId,
                Quantity = orderDetail.Quantity,
                VariantId = orderDetail.VariantId,

            });
            _context.SaveChanges();

            AddOrder(order, orderDetail);

            return res;
        }
        public BusiessLayerResult<Order> AddOrder(Order order, OrderDetail orderDetail)
        {
            BusiessLayerResult<Order> res = new BusiessLayerResult<Order>();
            var updateUserNullBasket = _context.Users.Where(x => x.Id == order.UserId && x.BasketId != null).FirstOrDefault();
            var updateUserNullOrder = _context.Orders.Where(x => x.UserId == order.UserId).FirstOrDefault();
            if (updateUserNullBasket == null && updateUserNullOrder == null)
            {
                _context.Orders.Add(new Order
                {
                    CargoFollow = order.CargoFollow,
                    Basket = new Basket
                    {
                        ProductId = orderDetail.ProductId,
                        Quantity = orderDetail.Quantity,
                        VariantId = orderDetail.VariantId,
                        UserId = order.UserId
                    },
                    OrderStatus = order.OrderStatus,
                    OrderStatusId = order.OrderStatusId,
                    SellBy = order.SellBy,
                    UserId = order.UserId,
                    PaymentMethodId = orderDetail.PaymentMethodId,
                    OrderDetail = new OrderDetail
                    {
                        CargoId = orderDetail.CargoId,
                        PaymentMethodId = orderDetail.PaymentMethodId,
                        ProductId = orderDetail.ProductId,
                        PropertyId = orderDetail.PropertyId,
                        Quantity = orderDetail.Quantity,
                        VariantId = orderDetail.VariantId,
                        Price = orderDetail.Price,
                        Kdv = orderDetail.Kdv,
                        Total = orderDetail.Total,
                        SellBy = order.SellBy,
                        Name = orderDetail.Name,
                        UserId = order.UserId,
                    }


                });
                _context.SaveChanges();
                var updateProduct = _context.Products.Where(x => x.Id == orderDetail.ProductId).FirstOrDefault();
                var updateUserBasket = _context.Baskets.Where(x => x.UserId == order.UserId).FirstOrDefault();
                var updateUser = _context.Users.Where(x => x.Id == order.UserId).FirstOrDefault();
                updateProduct.Piece -= orderDetail.Quantity;
                updateUser.BasketId = updateUserBasket.Id;
                _context.SaveChanges();
            }
            else
            {
                _context.Orders.Add(new Order
                {
                    CargoFollow = order.CargoFollow,
                    BasketId = updateUserNullBasket.BasketId,
                    OrderStatus = order.OrderStatus,
                    OrderStatusId = order.OrderStatusId,
                    SellBy = order.SellBy,
                    UserId = order.UserId,
                    PaymentMethodId = orderDetail.PaymentMethodId,
                    OrderDetailId = updateUserNullOrder.Id,
                    OrderDetail = new OrderDetail
                    {
                        CargoId = orderDetail.CargoId,
                        PaymentMethodId = orderDetail.PaymentMethodId,
                        ProductId = orderDetail.ProductId,
                        PropertyId = orderDetail.PropertyId,
                        Quantity = orderDetail.Quantity,
                        VariantId = orderDetail.VariantId,
                        Price = orderDetail.Price,
                        Kdv = orderDetail.Kdv,
                        Total = orderDetail.Total,
                        SellBy = order.SellBy,
                        Name = orderDetail.Name,
                        UserId = order.UserId,
                    },
                

                });
                
                _context.Baskets.Add(new Basket
                {
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    VariantId = orderDetail.VariantId,
                    UserId = order.UserId,
                    UpperBasketId = updateUserNullBasket.BasketId

                });
                var updateProduct = _context.Products.Where(x => x.Id == orderDetail.ProductId).FirstOrDefault();
                updateProduct.Piece -= orderDetail.Quantity;
                _context.SaveChanges();
            }



            return res;
        }
        public List<Order> GetOrder(int UserId)
        {
            return _context.Orders.Where(x => x.UserId == UserId).ToList();
        }
        public List<Basket> GetBasket(int UserId)
        {
            return _context.Baskets.Where(x => x.UserId == UserId).ToList();
        }
        public List<OrderDetail> GetOrderDetail(int UserId)
        {
            return _context.OrderDetails.Where(x =>  x.UserId == UserId).ToList();
        }   
        public OrderStatus GetOrderStatus(int OrderStatusId)
        {
            return _context.OrderStatuses.Where(x =>  x.Id == OrderStatusId).FirstOrDefault();
        }
       
    }
}
