using Ledger.Models;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;

        public HomeController()
        {
            _ledgerService = new LedgerService();
        }

        public ActionResult Index()
        {
            return View(_ledgerService.GetList());
        }

    }
}