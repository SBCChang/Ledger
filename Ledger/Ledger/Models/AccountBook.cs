namespace Ledger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccountBook")]
    public partial class AccountBook
    {
        public Guid Id { get; set; }

        public int Categoryyy { get; set; }

        public int Amounttt { get; set; }

        public DateTime Dateee { get; set; }

        [Required]
        [StringLength(500)]
        public string Remarkkk { get; set; }
    }
}
