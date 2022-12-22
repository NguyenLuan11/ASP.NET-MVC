using System.Web;
using System.Web.Mvc;

namespace QUẢN_LÝ_THƯ_VIỆN
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
