using E_Commerce.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BusinnessLayer.Result
{
    public class BusiessLayerResult<T> where T : class
    {

        public List<ErrorMessageObj> Errors { get; private set; }
        public List<UrlView> UrlViews { get; private set; }

        public T Result { get; set; }

        public BusiessLayerResult()
        {
            // EĞER EROR NESNESINE BOŞ GELİRSE HATA FIRLATMAMASI İÇİN  CTOR AYAĞA KALDIRIRLIR
            Errors = new List<ErrorMessageObj>();
            UrlViews = new List<UrlView>();
        }
        public void AddError(ErrorMessageCode code, string message)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = message });
        }

        public void AddUrl(Url view, string category)
        {
            UrlViews.Add(new UrlView() { View = view, Message = category });
        }



    }
}
