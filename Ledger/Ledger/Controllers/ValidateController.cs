using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class ValidateController : Controller
    {
        // GET: Validate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DateFormat(DateTime dateTime)
        {
            bool result = (dateTime.Date <= DateTime.Now.Date);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}