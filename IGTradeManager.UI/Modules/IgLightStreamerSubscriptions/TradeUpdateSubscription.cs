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
                var confirms = update.GetNewValue("CONFIRMS");
                if (!string.IsNullOrEmpty(confirms))
                {
                    var confirmsResponse = JsonConvert.DeserializeObject<ConfirmsResponse>(confirms);
                }

                var opu = update.GetNewValue("OPU");
                if (!string.IsNullOrEmpty(opu))
                {
                    var openPositionUpdate = JsonConvert.DeserializeObject<IGOpenPositionUpdate>(opu);                    
                }

                var wou = update.GetNewValue("WOU");
                if (!string.IsNullOrEmpty(wou))
                {

                }
            }   

            base.OnUpdate(itemPos, itemName, update);
        }
    }
}
