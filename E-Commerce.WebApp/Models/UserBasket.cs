using E_Commerce.BusinnessLayer;
using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.WebApp.Models
{
    public class UserBasket
    {
        public User User { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        private List<BasketDetail> _BasketDetails = new List<BasketDetail>();
        public List<BasketDetail> BasketDetail

        {
            get { return _BasketDetails; }

        }

        public void BasketAdd(BasketDetail basketDetail,int id)
        {
            var basket = _BasketDetails.Where(x => x.ProducId == basketDetail.ProducId && x.Varyant == basketDetail.Varyant).FirstOrDefault();

            if (basket == null)
            {

                _BasketDetails.Add(new BasketDetail()
                {


                    Product = basketDetail.Product,
                    Varyant = basketDetail.Varyant,
                    Property = basketDetail.Property,
                    PropertyId = basketDetail.PropertyId,
                    VaryantId = basketDetail.VaryantId,
                    Quantity = basketDetail.Quantity,
                    Total = basketDetail.Total,
                    Count=1,
                    ProducId = basketDetail.ProducId,
                    SellBy = basketDetail.SellBy,
                    UserId = basketDetail.UserId,
                    CargoId = basketDetail.CargoId,
                    Kdv = basketDetail.Kdv,
                    Name = basketDetail.Name,
                    PaymentMethodId =basketDetail.PaymentMethodId,
                    Price = basketDetail.Price,


                });
               // _BasketDetails.RemoveAll(x => x.Count < 1);
               // Basket();
            }
            else
            {
               
                    basket.Quantity += basketDetail.Quantity;
                    basket.Total += basketDetail.Quantity * (basketDetail.Product.Price);
                
              
            }

        }
        public UserBasket Basket()
        {
            var list = (UserBasket)HttpContext.Current.Session["basket"];
            if (list == null)
            {
                if (ManagerSession.User != null)
                {

                    list = new UserBasket();
                    list.User = ManagerSession.User as User;
                    HttpContext.Current.Session["basket"] = list;
                }
                else
                {
                    list = new UserBasket();
                    HttpContext.Current.Session["basket"] = list;
                }



            }


            return list;
        }
        public void Del(BasketDetail deleteBasket)
        {

            _BasketDetails.RemoveAll(x => x.ProducId == deleteBasket.ProducId && x.Varyant == deleteBasket.Varyant);


        }
        public void Udate(BasketDetail updateBasket, int updateQuantity)
        {
            var produt = _BasketDetails.Where(x => x.Product.Id == updateBasket.Product.Id && x.Varyant == updateBasket.Varyant).FirstOrDefault();

            produt.Quantity = updateQuantity;


        }
        public double Total()
        {

            return (double)_BasketDetails.Sum(x => x.Quantity * x.Product.Price) + Kdv();
        }

        public double Kdv()
        {

            return (double)_BasketDetails.Sum(x => x.Quantity * x.Product.Price) * 0.18;
        }

        public double Subtotal()
        {

            return (double)_BasketDetails.Sum(x => x.Quantity * x.Product.Price) - Kdv();
        }

        public void Clear()
        {

            _BasketDetails.Clear();
        }

        public int NumberOfBaskets()
        {

            return _BasketDetails.Count();
        }
        public BasketDetail BasketsOfProductCount(int productId)
        {

            return _BasketDetails.Find(x => x.Product.Id == productId);
        }
    }
    public class BasketDetail
    {
        public int UserId { get; set; }
        public int ProducId { get; set; }
        public Product Product { get; set; }
        public string Varyant { get; set; }
        public int Quantity { get; set; }
        public int Kdv { get; set; }
        public decimal Price { get; set; }
        public int Total { get; set; }

        public string Name { get; set; }
        public string Property { get; set; }
        public int PropertyId { get; set; }
        public int VaryantId { get; set; }
        public int Count { get; set; }
        public int PaymentMethodId { get; set; }
        public int CargoId { get; set; }
        public DateTime SellBy { get; set; }
    }
}