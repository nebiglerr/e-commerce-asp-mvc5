using E_Commerce.BusinnessLayer;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.AdminApp.Models
{
    public class UseAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (ManagerSession.Admin != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/Login/Auth");
                return false;
            }

        }
    }
}