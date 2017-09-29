using Ledger.Models;
using Ledger.Repositories;
using Ledger.ViewModels;
using PagedList;
using System;
using System.Configuration;
using System.Net;
using System.Web.Mvc;

namespace Ledger.Areas.LedgerAdmin.Controllers
{

    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;
        private readonly int _pageSize = int.Parse(ConfigurationManager.AppSettings["PageSize"]);

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _ledgerService = new LedgerService(unitOfWork);
        }

        public ActionResult Index(int? page)
        {
            var result = _ledgerService.GetAllList().ToPagedList(page ?? 1, _pageSize);
            return View(result);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var target = _ledgerService.Find(id.Value);

            if (target == null)
            {
                return HttpNotFound();
            }
            return View(target);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string account, string password)
        {
            if (account.ToLower() == "admin" && password == "admin123")
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LedgerViewModel ledger)
        {
            if (ModelState.IsValid)
            {
                _ledgerService.Edit(new AccountBook
                {
                    Id = ledger.Id,
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