using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class TradeUpdateSubscription : HandyTableListenerAdapter, ITradeUpdateSubscription
    {
        public delegate void TradeSubscriptionUpdateEventHandler(TradeSubscriptionUpdateEventArgs e);
        public event TradeSubscriptionUpdateEventHandler TradeSubscriptionUpdate;

        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            var handler = TradeSubscriptionUpdate;
            if (handler != null)
            {
            }   

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
