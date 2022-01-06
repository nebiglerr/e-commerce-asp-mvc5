using E_Commerce.BusinnessLayer.AdminManager;
using E_Commerce.Entities.AdminViewModel;
using System.Web.Mvc;

namespace E_Commerce.AdminApp.Controllers
{

    public class LoginController : Controller
    {

        private readonly LoginManager _loginManager = new LoginManager();
        public ActionResult Auth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(LoginAddViews loginAddViews)
        {
            var res = _loginManager.Auth(loginAddViews);
            if (res.Result != null)
            {
                if (res.Result.IsAdmin == true)
                {

                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}