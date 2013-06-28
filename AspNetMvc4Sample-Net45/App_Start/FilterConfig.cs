using AspNetMvc4Sample_Net45.App_Start;
using System.Configuration;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc4Sample_Net45
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new JsonWebTokenValidationAttribute
            {
                Audience = ConfigurationManager.AppSettings["auth0:ClientId"],
                SymmetricKey = ConfigurationManager.AppSettings["auth0:ClientSecret"]
            });
        }
    }
}