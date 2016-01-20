using dto.endpoint.confirms;
using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class TradeSubscriptionUpdateEventArgs : EventArgs
    {
        public IGWorkingOrderUpdate IGWorkingOrderUpdate { get; set; }      
        public IGOpenPositionUpdate IGOpenPositionUpdate { get; set; }
        public ConfirmsResponse ConfirmsResponse { get; set; }
    }
}
