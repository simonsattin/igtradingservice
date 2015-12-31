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

        public MainWindowViewModel(IDataAccess dataAccess, IDataCache dataCache, IAccountService accountService)
        {
            _DataAccess = dataAccess;
            _DataCache = dataCache;
            _AccountService = accountService;

            _DataCache.PropertyChanged += _DataCache_PropertyChanged;
            _DataCache.DatabaseOrders.ListChanged += DatabaseOrders_ListChanged;
        }

        

        public void Login(string apiKey, string username, string password)
        {
            LogMessage = "Resetting data cache...";
            _DataCache.Reset();

            LogMessage = "Getting database orders...";
            //fill database orders
            var databaseOrders = _DataAccess.GetOrders();
            foreach (var item in databaseOrders)
            {
                _DataCache.DatabaseOrders.Add(item);
            }

            LogMessage = "Logging into Ig Account Service...";
            //login to IG
            _AccountService.Login(apiKey, username, password);

            LogMessage = "Filling Ig Working Orders...";
            //fill IG working orders
            _AccountService.LoadWorkingOrders();

            LoggedIn = true;

            LogMessage = string.Empty;
        }

        public void Logout()
        {
            _DataCache.Reset();

            _AccountService.Logout();

            LoggedIn = false;
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

        private string _AccountId;
        public string AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged();
                }        
            }
        }

        private string _AccountName;
        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                if (_AccountName != value)
                {
                    _AccountName = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Balance;
        public decimal? Balance
        {
            get { return _Balance; }
            set
            {
                if (_Balance != value)
                {
                    _Balance = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Deposit;
        public decimal? Deposit
        {
            get { return _Deposit; }
            set
            {
                if (_Deposit != value)
                {
                    _Deposit = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Available;
        public decimal? Available
        {
            get { return _Available; }
            set
            {
                if (_Available != value)
                {
                    _Available = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _ProfitAndLoss;
        public decimal? ProfitAndLoss
        {
            get { return _ProfitAndLoss; }
            set
            {
                if (_ProfitAndLoss != value)
                {
                    _ProfitAndLoss = value;
                    OnPropertyChanged();
                }
            }
        }

        private void _DataCache_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AccountId")
            {
                AccountId = _DataCache.AccountId;
            }

            if (e.PropertyName == "AccountName")
            {
                AccountName = _DataCache.AccountName;
            }

            if (e.PropertyName == "Balance")
            {
                Balance = _DataCache.Balance;
            }

            if (e.PropertyName == "Available")
            {
                Available = _DataCache.Available;
            }

            if (e.PropertyName == "ProfitAndLoss")
            {
                ProfitAndLoss = _DataCache.ProfitAndLoss;
            }

            if (e.PropertyName == "Deposit")
            {
                Deposit = _DataCache.Deposit;
            }
        }

        private void DatabaseOrders_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var changedDatabaseOrder = _DataCache.DatabaseOrders[e.NewIndex];
                var rowsUpdated = _DataAccess.SaveDatabaseOrder(changedDatabaseOrder);
                if (rowsUpdated == 1)
                {
                    LogMessage = string.Format("Updated order for '{0}' in database", changedDatabaseOrder.Ticker);
                }
            }           
        }
    }
}
