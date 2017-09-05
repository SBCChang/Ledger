using System.Web.Mvc;

namespace Ledger.Helper
{
    public static class HtmlExtensions
    {

        public static int GetRecordIndex(this HtmlHelper helper, int index)
        {
            return index = index > 10 ? 1 : index;
        }
    }
}