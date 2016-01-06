using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class MarketSubscription : HandyTableListenerAdapter, IMarketSubscription
    {
        public delegate void MarketSubscriptionTickEventHandler(MarketSubscriptionTickEventArgs e);
        public event MarketSubscriptionTickEventHandler MarketSubscriptionTick;

        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            var handler = MarketSubscriptionTick;
            if (handler != null)
            {   
                var eventargs = new MarketSubscriptionTickEventArgs()
                {
                    Ticker = itemName,
                    MidOpen = string.IsNullOrEmpty(update.GetNewValue("MID_OPEN")) ? 0 : Convert.ToDecimal(update.GetNewValue("MID_OPEN")),
                    High = string.IsNullOrEmpty(update.GetNewValue("HIGH")) ? 0 : Convert.ToDecimal(update.GetNewValue("HIGH")),
                    Low = string.IsNullOrEmpty(update.GetNewValue("LOW")) ? 0 : Convert.ToDecimal(update.GetNewValue("LOW")),
                    Change = string.IsNullOrEmpty(update.GetNewValue("CHANGE")) ? 0 : Convert.ToDecimal(update.GetNewValue("CHANGE")),
                    ChangePercent = string.IsNullOrEmpty(update.GetNewValue("CHANGE_PCT")) ? 0 : Convert.ToDecimal(update.GetNewValue("CHANGE_PCT")),
                    UpdateTime = string.IsNullOrEmpty(update.GetNewValue("UPDATE_TIME")) ? DateTime.MinValue : Convert.ToDateTime(update.GetNewValue("UPDATE_TIME")),
                    MarketDelay = update.GetNewValue("MARKET_DELAY"),
                    MarketState = update.GetNewValue("MARKET_STATE"),
                    Bid = string.IsNullOrEmpty(update.GetNewValue("BID")) ? 0 : Convert.ToDecimal(update.GetNewValue("BID")),
                    Offer = string.IsNullOrEmpty(update.GetNewValue("OFFER")) ? 0 : Convert.ToDecimal(update.GetNewValue("OFFER"))
                };
                handler(eventargs);
            }

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
