using Ledger.Models;
using Ledger.Repositories;
using Ledger.ViewModels;
using PagedList;
using System;
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

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Read(int? page)
        {
            var result = _ledgerService.GetList().ToPagedList(page ?? 1, _pageSize);

            return View(result);
        }

        [HttpPost]
        public ActionResult Create(LedgerViewModel ledger)
        {
            if (ModelState.IsValid)
            {
                _ledgerService.Add(new AccountBook
                {
                    Id = Guid.NewGuid(),
                    Categoryyy = (int)ledger.LedgerType,
                    Amounttt = ledger.Amount,
                    Dateee = ledger.Date,
                    Remarkkk = ledger.Remark
                });

                _ledgerService.Save();
                return RedirectToAction("Index");
            }
            return View(ledger);
        }

    }
}