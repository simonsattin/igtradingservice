using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public interface IRiskMetrics : INotifyPropertyChanged
    {
        decimal SpreadToApply { get; set; }
        decimal RiskPerTrade { get; set; }
        decimal MaxSpreadPercent { get; set; }
    }
}
