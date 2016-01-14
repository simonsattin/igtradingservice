using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Data
{
    public class AccountDataCache : DependancyObject, IAccountDataCache
    {
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

        private decimal? _Equity;
        public decimal? Equity
        {
            get
            {
                return _Equity;
            }
            set
            {
                if (_Equity != value)
                {
                    _Equity = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Margin;
        public decimal? Margin
        {
            get
            {
                return _Margin;
            }
            set
            {
                if (_Margin != value)
                {
                    _Margin = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Funds;
        public decimal? Funds
        {
            get
            {
                return _Funds;
            }
            set
            {
                if (_Funds != value)
                {
                    _Funds = value;
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
    }
}
