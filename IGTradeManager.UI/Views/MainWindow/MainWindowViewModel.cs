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
        private readonly IDataCache _DataCache;
        private readonly IAccountDataCache _AccountDataCache;
        private readonly IAccountService _AccountService;
        private readonly IOrdersService _OrdersService;
        private readonly IRiskMetrics _RiskMetrics;

        public MainWindowViewModel(IDataCache dataCache, IAccountDataCache accountDataCache, IAccountService accountService, IOrdersService ordersService, IRiskMetrics riskMetrics)
        {
            _DataCache = dataCache;
            _AccountService = accountService;
            _OrdersService = ordersService;
            _RiskMetrics = riskMetrics;
            _AccountDataCache = accountDataCache;
          
            PropertyChanged += MainWindowViewModel_PropertyChanged;
            _RiskMetrics.PropertyChanged += _RiskMetrics_PropertyChanged;
            _DataCache.PropertyChanged += _DataCache_PropertyChanged;

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

            LogMessage = "Filling IG Open Positions...";
            _AccountService.LoadOpenPositions();

            LogMessage = "Subscribing to LightStreamer service...";
            _AccountService.ConnectToLightStreamer();

            LogMessage = "Getting database orders...";
            _OrdersService.LoadDatabaseOrders();

            LogMessage = "Getting Market Details for database orders...";
            _AccountService.FillMinimumDealSizeForDatabaseOrders();

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

        public BindingList<IgOpenPosition> IgOpenPositions
        {
            get
            {
                return _DataCache.IgOpenPositions;
            }
        }

        public decimal? Equity
        {
            get { return _AccountDataCache.Equity; }
        }

        public decimal? ProfitAndLoss
        {
            get { return _AccountDataCache.ProfitAndLoss; }
        }

        public decimal? Funds
        {
            get { return _AccountDataCache.Funds; }
        }

        public decimal? Margin
        {
            get { return _AccountDataCache.Margin; }
        }    
        
        public string AccountId
        {
            get { return _AccountDataCache.AccountId; }
        } 

        public string AccountName
        {
            get { return _AccountDataCache.AccountName; }
        }


        private DateTime _HeartbeatUpdated;
        public DateTime HeartbeatUpdated
        {
            get { return _HeartbeatUpdated; }
            set
            {
                if (_HeartbeatUpdated != value)
                {
                    _HeartbeatUpdated = value;
                    OnPropertyChanged();
                }
            }
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

        private decimal _MaxSpreadPercent;
        public decimal MaxSpreadPercent
        {
            get { return _MaxSpreadPercent; }
            set
            {
                if (_MaxSpreadPercent != value)
                {
                    _MaxSpreadPercent = value;
                    OnPropertyChanged();
                }
            }
        }

        private void _RiskMetrics_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RiskPerTrade")
            {
                RiskPerTrade = _RiskMetrics.RiskPerTrade;
            }

            if (e.PropertyName == "SpreadToApply")
            {
                SpreadToApply = _RiskMetrics.SpreadToApply;
            }

            if (e.PropertyName == "MaxSpreadPercent")
            {
                MaxSpreadPercent = _RiskMetrics.MaxSpreadPercent;
            }
        }       

        private void _DataCache_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {            
            if (e.PropertyName == "HeartbeatUpdate")
            {
                HeartbeatUpdated = _DataCache.HeartbeatUpdate;
            }
        }

        private void MainWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RiskPerTrade")
            {
                _RiskMetrics.RiskPerTrade = RiskPerTrade;
            }

            if (e.PropertyName == "SpreadToApply")
            {
                _RiskMetrics.SpreadToApply = SpreadToApply;
            }

            if (e.PropertyName == "MaxSpreadPercent")
            {
                _RiskMetrics.MaxSpreadPercent = MaxSpreadPercent;
            }
        }        
    }
}
