using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class MarketSubscriptionTickEventArgs : EventArgs
    {
        public string Ticker { get; set; }
        public decimal MidOpen { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Change { get; set; }
        public decimal ChangePercent { get; set; }
        public DateTime UpdateTime { get; set; }
        public string MarketState { get; set; }
        public string MarketDelay { get; set; }
        public decimal Bid { get; set; }
        public decimal Offer { get; set; }        
    }
}
