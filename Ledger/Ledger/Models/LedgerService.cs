using Ledger.Enum;
using Ledger.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Ledger.Models
{
    public class LedgerService
    {
        private readonly LedgerDataContext _db;

        public LedgerService()
        {
            _db = new LedgerDataContext();
        }

        public IEnumerable<LedgerViewModel> GetData()
        {

            return _db.AccountBook.Select(a => new LedgerViewModel
            {
                LedgerType = (LedgerType)a.Categoryyy,
                Amount = a.Amounttt,
                Date = a.Dateee
            }).OrderBy(a=>a.Date);

        }

    }
}