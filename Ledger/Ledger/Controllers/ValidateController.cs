using System;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class ValidateController : Controller
    {

        public ActionResult BeforeToday(DateTime date)
        {
            bool result = (date.Date != DateTime.MinValue && date.Date <= DateTime.Now.Date);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}