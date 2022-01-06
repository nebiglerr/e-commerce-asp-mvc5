using E_Commerce.Entities.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.BusinnessLayer
{
   public  class ManagerSession
    {
        public static Object User
        {
            get
            {
                return Get<Object>("login");
               // return Get<User>("login");

            }

        }    
        public static Login Admin
        {
            get
            {
                return Get<Login>("admin");
               // return Get<User>("login");

            }

        }
        public static void Set<T>(string key, T obj)
        {


            HttpContext.Current.Session[key] = obj;

        }

        private static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }

            return default(T);
        }
        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }
        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
