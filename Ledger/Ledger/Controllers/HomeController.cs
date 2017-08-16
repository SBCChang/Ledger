using Ledger.Models;
using System.Web.Mvc;
using PagedList;

namespace Ledger.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;
        private int _pageSize = 10;

        public HomeController()
        {
            _ledgerService = new LedgerService();
        }

        public ActionResult Index(int? page)
        {
            var ledgers = _ledgerService.GetData();
            var currentPage = page ?? 1;
            var result = ledgers.ToPagedList(currentPage, _pageSize);

            return View(result);
        }

    }
}