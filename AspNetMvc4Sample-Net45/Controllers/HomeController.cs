﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvc4Sample_Net45.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "";
            ViewBag.JsonWebToken = ClaimsPrincipal.Current.FindFirst("id_token");

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Foo()
        {
            return Json(new { IsAuthenticated = ClaimsPrincipal.Current.Identity.IsAuthenticated }, JsonRequestBehavior.AllowGet);
        }
    }
}
