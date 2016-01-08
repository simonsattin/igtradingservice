using IGPublicPcl;
using IGTradeManager.UI.Data;
using IGTradeManager.UI.Data.DataAccess;
using IGTradeManager.UI.Model;
using IGTradeManager.UI.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {        
        private readonly IDataAccess _DataAccess;
        private readonly IDataCache _DataCache;
        private readonly IAccountService _AccountService;
        private readonly IOrdersService _OrdersService;

        public MainWindowViewModel(IDataAccess dataAccess, IDataCache dataCache, IAccountService accountService, IOrdersService ordersService)
        {
            _DataAccess = dataAccess;
            _DataCache = dataCache;
            _AccountService = accountService;
            _OrdersService = ordersService;   
          
            PropertyChanged += MainWindowViewModel_PropertyChanged;

            LoggedOut = true;
        }       

        public void Login(string apiKey, string username, string password)
        {
            LogMessage = "Resetting data cache...";
            _DataCache.Reset();            

            LogMessage = "Logging into Ig Account Service...";
            //login to IG
            _AccountService.Login(apiKey, username, password);

            LogMessage = "Filling Ig Working Orders...";
            //fill IG working orders
            _AccountService.LoadWorkingOrders();

            LogMessage = "Subscribing to LightStreamer service...";
            _AccountService.ConnectToLightStreamer();

            LogMessage = "Getting database orders...";
            _OrdersService.LoadDatabaseOrders();

            LogMessage = "Subscribe tickers for market details...";
            foreach (var order in _DataCache.DatabaseOrders)
            {
                _AccountService.SubscribeDatabaseOrderToMarketListener(order);
            }

            LoggedIn = true;
            LoggedOut = false;

            LogMessage = string.Empty;
        }

        public void Logout()
        {
            _DataCache.Reset();

            _AccountService.Logout();

            LoggedIn = false;
            LoggedOut = true;
        }

        public void DeleteDatabaseOrder(DatabaseOrder order)
        {
            _OrdersService.DeleteDatabaseOrder(order);
        }

        public void UpdateDatabaseOrder(DatabaseOrder order)
        {
            _OrdersService.UpdateDatabaseOrder(order);
        }

        public BindingList<DatabaseOrder> DatabaseOrders
        {
            get
            {
                return _DataCache.DatabaseOrders;
            }
        }

        public BindingList<IgWorkingOrder> IgWorkingOrders
        {
            get
            {
                return _DataCache.IgWorkingOrders;
            }
        }


        public IDataCache DataCache
        {
            get { return _DataCache; }
        }

        private bool _LoggedIn;
        public bool LoggedIn
        {
            get { return _LoggedIn; }
            set
            {
                if (_LoggedIn != value)
                {
                    _LoggedIn = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _LoggedOut;
        public bool LoggedOut
        {
            get { return _LoggedOut; }
            set
            {
                if (_LoggedOut != value)
                {
                    _LoggedOut = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _LogMessage;
        public string LogMessage
        {
            get { return _LogMessage; }
            set
            {
                if (_LogMessage != value)
                {
                    _LogMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _RiskPerTrade;
        public decimal RiskPerTrade
        {
            get { return _RiskPerTrade; }
            set
            {
                if (_RiskPerTrade != value)
                {
                    _RiskPerTrade = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _SpreadToApply;
        public decimal SpreadToApply
        {
            get { return _SpreadToApply; }
            set
            {
                if (_SpreadToApply != value)
                {
                    _SpreadToApply = value;
                    OnPropertyChanged();
                }
            }
        }        

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SpreadToApply")
            {
                foreach (var order in DatabaseOrders)
                {
                    order.SpreadToApply = SpreadToApply;
                }
            }

            if (e.PropertyName == "RiskPerTrade")
            {
                foreach (var order in DatabaseOrders)
                {
                    order.RiskPerTrade = RiskPerTrade;
                }
            }
        }        
    }
}
