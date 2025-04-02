using System.Web;
using System.Web.Mvc;

namespace App_Servicio_2_Imgs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
