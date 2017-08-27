using Ledger.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ledger.ViewModels
{
    public class LedgerViewModel
    {
        [Required]
        [Display(Name = "類別")]
        public LedgerType LedgerType { get; set; }

        [Required]
        [Display(Name = "日期")]
        [Remote("DateFormat", "Validate", ErrorMessage = "日期不得大於今天")]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "必須為正整數")]
        [Display(Name = "金額")]
        public int Amount { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "最多100個字元")]
        [Display(Name = "備註")]
        public string Remark { get; set; }

    }
}