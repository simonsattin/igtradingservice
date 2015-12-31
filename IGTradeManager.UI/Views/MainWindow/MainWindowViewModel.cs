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
        }        

        public void Login(string apiKey, string username, string password)
        {
            _DataCache.Reset();

            //fill database orders
            var databaseOrders = _DataAccess.GetOrders();
            foreach (var item in databaseOrders)
            {
                _DataCache.DatabaseOrders.Add(item);
            }

            //login to IG
            _AccountService.Login(apiKey, username, password);            
        }

        public void Logout()
        {
            _DataCache.Reset();

            _AccountService.Logout();            
        }

        public BindingList<DatabaseOrder> DatabaseOrders
        {
            get
            {
                return _DataCache.DatabaseOrders;
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
    }
}
