using IGTradeManager.UI.Data;
using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.MainWindow
{
    public interface IMainWindowViewModel : IController
    {
        void Login(string apiKey, string username, string password);
        void Logout();
        void DeleteDatabaseOrder(DatabaseOrder order);
        void UpdateDatabaseOrder(DatabaseOrder order);

        //IDataCache DataCache { get; }
        //IAccountDataCache AccountDataCache { get; }

        decimal? Equity { get; }
        decimal? ProfitAndLoss { get; }
        decimal? Funds { get; }
        decimal? Margin { get; }

        string AccountId { get; }
        string AccountName { get; }        

        DateTime HeartbeatUpdated { get; }
        bool LoggedIn { get; }
        bool LoggedOut { get; }     

        decimal RiskPerTrade { get; set; }            
        decimal SpreadToApply { get; set; }
        decimal MaxSpreadPercent { get; set; }

        BindingList<DatabaseOrder> DatabaseOrders { get; }
        BindingList<IgWorkingOrder> IgWorkingOrders { get; }
        BindingList<IgOpenPosition> IgOpenPositions { get; }
    }
}
