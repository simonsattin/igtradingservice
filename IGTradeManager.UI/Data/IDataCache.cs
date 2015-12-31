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

        string AccountId { get; set; }
        string AccountName { get; set; }
        decimal? Balance { get; set; }
        decimal? ProfitAndLoss { get; set; }
        decimal? Deposit { get; set; }
        decimal? Available { get; set; }
    }
}
