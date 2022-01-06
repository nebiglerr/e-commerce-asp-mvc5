using E_Commerce.BusinnessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.WebApp.Models
{
    public class UseAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (ManagerSession.User != null)
            {
                return true;
            }
            else
            {
                httpContext.Response.Redirect("/");
                return false;
            }

        }
    }
}