using System;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AspNetMvc4Sample_Net45.App_Start.ClaimsCookieConfig), "PreAppStart")]

namespace AspNetMvc4Sample_Net45.App_Start
{
    public static class ClaimsCookieConfig
    {
        public static void PreAppStart()
        {
            DynamicModuleUtility.RegisterModule(typeof(ClaimsCookie.ClaimsCookieModule));
        }
    }
}