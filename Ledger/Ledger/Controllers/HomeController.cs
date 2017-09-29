using Ledger.Models;
using Ledger.Repositories;
using Ledger.ViewModels;
using PagedList;
using System;
using System.Configuration;
using System.Web.Mvc;

namespace Ledger.Controllers
{
    [RoutePrefix("SkillTree")]
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;
        private readonly int _pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _ledgerService = new LedgerService(unitOfWork);
        }

        [Route]
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Read(int? page)
        {
            var result = _ledgerService.GetAllList().ToPagedList(page ?? 1, _pageSize);

            return View(result);
        }

        [Route("{year:range(0001,9999)}/{month:range(1,12)}")]
        public ActionResult ReadYearMonth(int year, int month, int? page)
        {
            var result = _ledgerService.GetListByYearAndMonth(year, month)
                                       .ToPagedList(page ?? 1, _pageSize);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return View("Index", ledger);
        }

    }
}