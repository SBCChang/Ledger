using System.Web.Mvc;

namespace Ledger.Helper
{
    public static class ColorHtmlExtensions
    {

        public static bool LedgerType(this HtmlHelper helper, int category)
        {
            return category == 0;
        }
    }
}