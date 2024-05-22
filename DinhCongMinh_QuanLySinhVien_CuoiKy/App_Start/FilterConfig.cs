using System.Web;
using System.Web.Mvc;

namespace DinhCongMinh_QuanLySinhVien_CuoiKy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
