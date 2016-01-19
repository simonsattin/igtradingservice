using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules.IgLightStreamerSubscriptions
{
    public class HeartbeatUpdateEventArgs : EventArgs
    {
        public DateTime HeartbeatLastUpdated { get; set; }
    }
}
