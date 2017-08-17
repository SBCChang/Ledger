using Ledger.Models;
using System.Data.Entity;

namespace Ledger.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        public DbContext DbContext { get; set; }

        public EFUnitOfWork()
        {
            DbContext = new LedgerDataContext();
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
        
    }
}