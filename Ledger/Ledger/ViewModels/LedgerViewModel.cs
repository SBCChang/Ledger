using Ledger.Enum;
using System;

namespace Ledger.ViewModels
{
    public class LedgerViewModel
    {

        public LedgerType LedgerType { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

    }
}