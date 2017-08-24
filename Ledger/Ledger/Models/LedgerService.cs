using Ledger.Enum;
using Ledger.Repositories;
using Ledger.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Ledger.Models
{
    public class LedgerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AccountBook> _accountBookRep;

        public LedgerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBookRep = new Repository<AccountBook>(_unitOfWork);
        }

        public IList<LedgerViewModel> GetList()
        {
            return _accountBookRep.GetAllData().Select(a => new LedgerViewModel
            { 
                LedgerType = (LedgerType)a.Categoryyy,
                Amount = a.Amounttt,
                Date = a.Dateee
            }).OrderBy(a=>a.Date).ToList();
        }

        public void Add(AccountBook accountBook)
        {
            _accountBookRep.Create(accountBook);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

    }
}