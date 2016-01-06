using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public interface IMarketSubscription : IHandyTableListener
    {
        event MarketSubscription.MarketSubscriptionTickEventHandler MarketSubscriptionTick;
    }
}
