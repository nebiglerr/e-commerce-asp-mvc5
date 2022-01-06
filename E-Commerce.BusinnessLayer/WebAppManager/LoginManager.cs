using E_Commerce.BusinnessLayer.Abstract;
using E_Commerce.BusinnessLayer.Result;
using E_Commerce.DataAccessLayer.EntityFramework;
using E_Commerce.Entities.Db;
using E_Commerce.Entities.Messages;
using E_Commerce.Entities.WebAppViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.WebAppManager
{
    public class LoginManager : ManagerBase<User>
    {
        private readonly DatabaseContext _context = new DatabaseContext();

        public BusiessLayerResult<User> Login(LoginViewModel loginViewModel)
        {
            BusiessLayerResult<User> res = new BusiessLayerResult<User>();

            res.Result = Find(x => x.Email == loginViewModel.Email && x.Pass == loginViewModel.Pass);
            if (res.Result != null)
            {
                ManagerSession.Set<User>("login", res.Result);
                // _ = ManagerSession.ObjectSession;
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı Adı yada Şifre Hatalı");

            }
            return res;
        }
        public BusiessLayerResult<User> Register(RegisterViewModel registerViewModel)
        {
            BusiessLayerResult<User> res = new BusiessLayerResult<User>();

            // res.Result = _context.Logins.Where(x => x.UserName == loginAddViews.UserName && x.Pass == loginAddViews.Pass  && x.IsAdmin == true).FirstOrDefault();
            res.Result = Find(x => x.Email == registerViewModel.Email && x.Pass == registerViewModel.Pass);
            if (res.Result != null)
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Aynı kullanıcı adı mevcut");
                // _ = ManagerSession.ObjectSession;
            }
            else if (res.Result == null)
            {
                _context.Users.Add(new User
                {
                    LoginId = 3,
                    DateOfBirth = DateTime.Now,
                    Email = registerViewModel.Email,
                    Pass = registerViewModel.Pass

                });
                _context.SaveChanges();
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Herhangi Bir Hata Oluştu");
            }
            return res;
        }
        public BusiessLayerResult<User> AccountUpdate(UserViewModel UserViewModel)
        {
            BusiessLayerResult<User> res = new BusiessLayerResult<User>();

            // res.Result = _context.Logins.Where(x => x.UserName == loginAddViews.UserName && x.Pass == loginAddViews.Pass  && x.IsAdmin == true).FirstOrDefault();
          var user =  ManagerSession.User as User;
            UserViewModel.Id = user.Id;
           res.Result = _context.Users.Where(x => x.Id == UserViewModel.Id).FirstOrDefault();
            if (res.Result != null)
            {
                res.Result.BillingAddress = UserViewModel.BillingAddress;
                res.Result.DeliveryAddress = UserViewModel.DeliveryAddress;
                res.Result.Email = UserViewModel.Email;
                res.Result.Name = UserViewModel.Name;
                res.Result.SurName = UserViewModel.SurName;
                _context.SaveChanges();
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Herhangi Bir Hata Oluştu");
            }
            return res;
        }  
        public BusiessLayerResult<User> PassUpdate(ChangePasswordView changePasswordView)
        {
            BusiessLayerResult<User> res = new BusiessLayerResult<User>();

            // res.Result = _context.Logins.Where(x => x.UserName == loginAddViews.UserName && x.Pass == loginAddViews.Pass  && x.IsAdmin == true).FirstOrDefault();
          var user =  ManagerSession.User as User;
            changePasswordView.Id = user.Id;
           res.Result = _context.Users.Where(x => x.Id == changePasswordView.Id).FirstOrDefault();
            if (res.Result != null)
            {
                if (res.Result.Pass == changePasswordView.OldPass)
                {
                    res.Result.Pass = changePasswordView.NewPass;
                    _context.SaveChanges();
                }
                else
                {
                    res.AddError(ErrorMessageCode.UserCouldNotFind, "Girmiş Olduğunuz Şifre Hatalı");
                }            
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Herhangi Bir Hata Oluştu");
            }
            return res;
        }
    }
}
