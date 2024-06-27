using System.Web;
using System.Web.Mvc;

namespace Tour_and_Tourism
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
