using Ledger.Enum;
using Ledger.ViewModels;
using System;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Ledger.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View(new List<LedgerViewModel>()
            {
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 1), Amount = 300},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 2), Amount = 16000},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 3), Amount = 8000},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 4), Amount = 500},
                new LedgerViewModel() { LedgerType = LedgerType.收入, Date = new DateTime(2016, 1, 5), Amount = 1000000},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 5), Amount = 500},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 5), Amount = 1500},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 6), Amount = 10500},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 6), Amount = 3500},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 7), Amount = 200},
                new LedgerViewModel() { LedgerType = LedgerType.支出, Date = new DateTime(2016, 1, 8), Amount = 500}
            });
        }

    }
}