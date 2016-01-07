using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public interface IAccountUpdateSubscription : IHandyTableListener
    {
        event AccountUpdateSubscription.AccountSubscriptionUpdateEventHandler AccountSubscriptionUpdate;
    }
}
