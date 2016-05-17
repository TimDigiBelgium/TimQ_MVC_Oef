using System.Web;
using System.Web.Mvc;

namespace TimQ_MVC_Oef
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
