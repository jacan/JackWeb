using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JackWeb.Controllers
{
    public class FacebookController : Controller
    {

        public FacebookController()
        {

        }

        //
        // GET: /Facebook/

        public ActionResult Index()
        {
            return View();
        }

    }
}
