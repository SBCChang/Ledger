using System;
using System.Data.Entity;

namespace Ledger.Repositories
{
    public interface IUnitOfWork : IDisposable
    {

        DbContext DbContext { get; set; }

        void Save();

    }
}
