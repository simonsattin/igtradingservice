using dto.endpoint.confirms;
using IGPublicPcl;
using IGTradeManager.UI.Model;
using Lightstreamer.DotNet.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                var eventargs = new TradeSubscriptionUpdateEventArgs();

                var confirms = update.GetNewValue("CONFIRMS");
                if (!string.IsNullOrEmpty(confirms))
                {
                    eventargs.ConfirmsResponse = JsonConvert.DeserializeObject<ConfirmsResponse>(confirms);
                }

                var opu = update.GetNewValue("OPU");
                if (!string.IsNullOrEmpty(opu))
                {
                    eventargs.IGOpenPositionUpdate = JsonConvert.DeserializeObject<IGOpenPositionUpdate>(opu);                    
                }

                var wou = update.GetNewValue("WOU");
                if (!string.IsNullOrEmpty(wou))
                {                    
                    eventargs.IGWorkingOrderUpdate = JsonConvert.DeserializeObject<IGWorkingOrderUpdate>(wou);
                }

                handler(eventargs);
            }   

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
