using IGTradeManager.UI.Data;
using IGTradeManager.UI.Data.DataAccess;
using IGTradeManager.UI.Model;
using IGTradeManager.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.NewDatabaseOrder
{
    public class NewDatabaseOrderViewModel : ViewModelBase, INewDatabaseOrderViewModel
    {
        private readonly IDataAccess _DataAccess;
        private readonly IDataCache _DataCache;
        private readonly IOrdersService _OrdersService;
        private readonly IAccountService _AccountService;

        public NewDatabaseOrderViewModel(IDataAccess dataAccess, IDataCache dataCache, IOrdersService ordersService, IAccountService accountService)
        {
            _DataAccess = dataAccess;
            _DataCache = dataCache;
            _OrdersService = ordersService;
            _AccountService = accountService;
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Ticker;
        public string Ticker
        {
            get { return _Ticker; }
            set
            {
                if (_Ticker != value)
                {
                    _Ticker = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _IgInstrumentName;
        public string IgInstrumentName
        {
            get { return _IgInstrumentName; }
            set
            {
                if (_IgInstrumentName != value)
                {
                    _IgInstrumentName = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Expiry;
        public string Expiry
        {
            get { return _Expiry; }
            set
            {
                if (_Expiry != value)
                {
                    _Expiry = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _NextEarnings;
        public DateTime NextEarnings
        {
            get { return _NextEarnings; }
            set
            {
                if (_NextEarnings != value)
                {
                    _NextEarnings = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _BreakoutLevel;
        public decimal BreakoutLevel
        {
            get { return _BreakoutLevel; }
            set
            {
                if (_BreakoutLevel != value)
                {
                    _BreakoutLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _StopDistance;
        public decimal StopDistance
        {
            get { return _StopDistance; }
            set
            {
                if (_StopDistance != value)
                {
                    _StopDistance = value;
                    OnPropertyChanged();
                }
            }
        }

        public void InsertDatabaseOrder()
        {
            var order = new DatabaseOrder()
            {
                Name = Name.Trim(),
                Ticker = Ticker.Trim(),
                IgInstrument = IgInstrumentName.Trim(),
                Expiry = Expiry.Trim(),
                NextEarnings = NextEarnings,
                BreakoutLevel = BreakoutLevel,
                StopDistance = StopDistance
            };

            _OrdersService.InsertDatabaseOrder(order);

            _AccountService.SubscribeDatabaseOrderToMarketListener(order);         
        }
    }
}
