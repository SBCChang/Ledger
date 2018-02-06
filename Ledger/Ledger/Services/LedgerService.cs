using Ledger.Enums;
using Ledger.Repositories;
using Ledger.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IList<LedgerViewModel> GetAllList()
        {
            return _accountBookRep.GetAllData().ToList().Select(a => new LedgerViewModel
            {
                Id = a.Id,
                LedgerType = (LedgerType)a.Categoryyy,
                Amount = a.Amounttt,
                Date = a.Dateee,
                Remark = a.Remarkkk
            }).OrderBy(a => a.Date).ToList();
        }

        public IList<LedgerViewModel> GetListByYearAndMonth(int year, int month)
        {
            return _accountBookRep.Query(a => a.Dateee.Year == year && a.Dateee.Month == month).Select(a => new LedgerViewModel
            {
                LedgerType = (LedgerType)a.Categoryyy,
                Amount = a.Amounttt,
                Date = a.Dateee
            }).OrderBy(a => a.Date).ToList();
        }

        public void Add(AccountBook accountBook)
        {
            _accountBookRep.Create(accountBook);
        }

        public LedgerViewModel Find(Guid id)
        {
            var target = _accountBookRep.GetSingle(a => a.Id == id);

            return new LedgerViewModel()
            {
                Id = target.Id,
                Date = target.Dateee,
                Amount = target.Amounttt,
                LedgerType = (LedgerType)target.Categoryyy,
                Remark = target.Remarkkk
            };
        }

        public void Edit(AccountBook accountBook)
        {
            _unitOfWork.DbContext.Entry(accountBook).State = EntityState.Modified;
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

    }
}