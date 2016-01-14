using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Data
{
    public interface IDataCache : INotifyPropertyChanged
    {
        void Reset();        

        BindingList<DatabaseOrder> DatabaseOrders { get; }
        BindingList<IgWorkingOrder> IgWorkingOrders { get; }
        BindingList<IgOpenPosition> IgOpenPositions { get; }

        DateTime HeartbeatUpdate { get; set; }        
    }
}
