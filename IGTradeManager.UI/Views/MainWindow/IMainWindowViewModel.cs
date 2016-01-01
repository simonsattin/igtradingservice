﻿using IGTradeManager.UI.Model;
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

        bool LoggedIn { get; }
        bool LoggedOut { get; }
        string LogMessage { get; }
        string AccountId { get; }
        string AccountName { get; }
        decimal? Available { get;  }
        decimal? Deposit { get;  }
        decimal? Balance { get;  }
        decimal? ProfitAndLoss { get; }

        BindingList<DatabaseOrder> DatabaseOrders { get; }
        BindingList<IgWorkingOrder> IgWorkingOrders { get; }
    }
}
