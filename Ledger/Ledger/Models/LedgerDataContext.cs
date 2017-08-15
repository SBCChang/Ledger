namespace Ledger.Models
{
    using System.Data.Entity;

    public partial class LedgerDataContext : DbContext
    {
        public LedgerDataContext()
            : base("name=LedgerDataContext")
        {
        }

        public virtual DbSet<AccountBook> AccountBook { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
