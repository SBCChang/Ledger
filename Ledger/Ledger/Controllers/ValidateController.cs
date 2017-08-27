using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class ValidateController : Controller
    {

        public ActionResult DateFormat(DateTime date)
        {
            bool result = (date.Date <= DateTime.Now.Date);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}