using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Data
{
    public interface IAccountDataCache : INotifyPropertyChanged
    {
        string AccountId { get; set; }
        string AccountName { get; set; }

        decimal? Equity { get; set; }
        decimal? ProfitAndLoss { get; set; }
        decimal? Funds { get; set; }
        decimal? Margin { get; set; }
        decimal? Balance { get; set; }        
        decimal? Deposit { get; set; }
        decimal? Available { get; set; }
    }
}
