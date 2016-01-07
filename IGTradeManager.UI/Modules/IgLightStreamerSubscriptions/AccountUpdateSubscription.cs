using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class AccountUpdateSubscription : HandyTableListenerAdapter, IAccountUpdateSubscription
    {
        public delegate void AccountSubscriptionUpdateEventHandler(AccountSubscriptionUpdateEventArgs e);
        public event AccountSubscriptionUpdateEventHandler AccountSubscriptionUpdate;

        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            var handler = AccountSubscriptionUpdate;
            if (handler != null)
            {
                handler(new AccountSubscriptionUpdateEventArgs());
            }

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
