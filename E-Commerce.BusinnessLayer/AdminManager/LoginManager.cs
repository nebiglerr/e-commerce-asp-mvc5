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
using System.Web;
using System.Web.Security;

namespace E_Commerce.BusinnessLayer.AdminManager
{
    public class LoginManager : ManagerBase<Login>
    {
        private DatabaseContext _context = new DatabaseContext();
        public BusiessLayerResult<Login> Auth(LoginAddViews loginAddViews)
        {
            BusiessLayerResult<Login> res = new BusiessLayerResult<Login>();

           // res.Result = _context.Logins.Where(x => x.UserName == loginAddViews.UserName && x.Pass == loginAddViews.Pass  && x.IsAdmin == true).FirstOrDefault();
            res.Result = Find(x => x.UserName == loginAddViews.UserName && x.Pass == loginAddViews.Pass && x.IsAdmin == true);
             if (res.Result != null)
            {
                ManagerSession.Set<Login>("admin", res.Result);
               // _ = ManagerSession.ObjectSession;
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı Adı yada Şifre Hatalı");

            }
            return res;
        }
    }
}
