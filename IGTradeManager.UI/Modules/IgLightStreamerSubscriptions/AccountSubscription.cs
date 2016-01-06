using IGPublicPcl;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class AccountSubscription : HandyTableListenerAdapter
    {
        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
