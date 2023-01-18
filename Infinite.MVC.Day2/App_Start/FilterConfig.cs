using System.Web;
using System.Web.Mvc;

namespace Infinite.MVC.Day2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
