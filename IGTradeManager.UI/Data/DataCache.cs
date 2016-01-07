using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Data
{
    public class DataCache : DependancyObject, IDataCache
    {
        private readonly object _DatabaseOrdersLock = new object();
        private readonly object _IgWorkingOrdersLock = new object();

        public DataCache()
        {
            _DatabaseOrders = new BindingList<DatabaseOrder>();
            _IgWorkingOrders = new BindingList<IgWorkingOrder>();
        }

        private BindingList<DatabaseOrder> _DatabaseOrders;
        public BindingList<DatabaseOrder> DatabaseOrders
        {
            get { lock(_DatabaseOrdersLock) { return _DatabaseOrders; } }
            private set
            {
                lock(_DatabaseOrdersLock)
                {
                    if (_DatabaseOrders != value)
                    {
                        _DatabaseOrders = value;
                        OnPropertyChanged();
                    }
                }                                
            }
        }


        private BindingList<IgWorkingOrder> _IgWorkingOrders;
        public BindingList<IgWorkingOrder> IgWorkingOrders
        {
            get { lock (_IgWorkingOrdersLock) { return _IgWorkingOrders; } }
            private set
            {
                lock (_IgWorkingOrdersLock)
                {
                    if (_IgWorkingOrders != value)
                    {
                        _IgWorkingOrders = value;
                        OnPropertyChanged();
                    }
                }
            }
        }        

        private decimal _RiskPerTrade;
        public decimal RiskPerTrade
        {
            get
            {
                return _RiskPerTrade;
            }
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
            get
            {
                return _SpreadToApply;
            }
            set
            {
                if (_SpreadToApply != value)
                {
                    _SpreadToApply = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _AccountId;
        public string AccountId
        {
            get
            {
                return _AccountId;
            }
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
            get
            {
                return _AccountName;
            }
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
            get
            {
                return _Balance;
            }
            set
            {
                if (_Balance != value)
                {
                    _Balance = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _ProfitAndLoss;
        public decimal? ProfitAndLoss
        {
            get
            {
                return _ProfitAndLoss;
            }
            set
            {
                if (_ProfitAndLoss != value)
                {
                    _ProfitAndLoss = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Deposit;
        public decimal? Deposit
        {
            get
            {
                return _Deposit;
            }
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
            get
            {
                return _Available;
            }
            set
            {
                if (_Available != value)
                {
                    _Available = value;
                    OnPropertyChanged();
                }
            }
        }        

        public void Reset()
        {
            DatabaseOrders.Clear();
            IgWorkingOrders.Clear();

            AccountId = string.Empty;
            AccountName = string.Empty;
            Balance = null;
            Deposit = null;
            Available = null;
            ProfitAndLoss = null;
        }   
    }
}
