using Ledger.Models;
using Ledger.Repositories;
using PagedList;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;
        private readonly int _pageSize = 10;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _ledgerService = new LedgerService(unitOfWork);
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