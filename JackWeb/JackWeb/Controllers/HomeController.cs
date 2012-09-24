using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Let's build some new stuff..";

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "A playground/sandbox for a software developer in constant development";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Should you have any interest in contacting me personally, please checkout my details";

			return View();
		}
	}
}
