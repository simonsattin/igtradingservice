using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class AccountSubscriptionUpdateEventArgs : EventArgs
    {
        public decimal PNL { get; set; }
        public decimal Deposit { get; set; }
        public decimal UsedMargin { get; set; }
        public decimal AmountDue { get; set; }
        public decimal AvailableCash { get; set; }
        public decimal Equity { get; set; }
        public decimal Funds { get; set; }
    }
}
