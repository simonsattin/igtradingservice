using IGPublicPcl;
using System;
using Lightstreamer.DotNet.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class HeartbeatUpdateSubscription : HandyTableListenerAdapter, IHeartbeatUpdateSubscription
    {
        public delegate void HeartbeatUpdateEventHandler(HeartbeatUpdateEventArgs e);
        public event HeartbeatUpdateEventHandler HeartbeatUpdate;

        public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
        {
            var handler = HeartbeatUpdate;
            if (handler != null)
            {
                var eventargs = new HeartbeatUpdateEventArgs()
                {
                    HeartbeatLastUpdated = DateTime.Now
                };
                handler(eventargs);
            }

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
