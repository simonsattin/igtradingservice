using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class IgWorkingOrder : DependancyObject
    {
        private string _DealId;
        public string DealId
        {
            get { return _DealId; }
            set
            {
                if (_DealId != value)
                {
                    _DealId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set
            {
                if (_Direction != value)
                {
                    _Direction = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Epic;
        public string Epic
        {
            get { return _Epic; }
            set
            {
                if (_Epic != value)
                {
                    _Epic = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _OrderSize;
        public decimal? OrderSize
        {
            get { return _OrderSize; }
            set
            {
                if (_OrderSize != value)
                {
                    _OrderSize = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _OrderLevel;
        public decimal? OrderLevel
        {
            get { return _OrderLevel; }
            set
            {
                if (_OrderLevel != value)
                {
                    _OrderLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _TimeInForce;
        public string TimeInForce
        {
            get { return _TimeInForce; }
            set
            {
                if (_TimeInForce != value)
                {
                    _TimeInForce = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _GoodTillDate;
        public string GoodTillDate
        {
            get { return _GoodTillDate; }
            set
            {
                if (_GoodTillDate != value)
                {
                    _GoodTillDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _CreatedDate;
        public string CreatedDate
        {
            get { return _CreatedDate; }
            set
            {
                if (_CreatedDate != value)
                {
                    _CreatedDate = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _GuaranteedStop;
        public bool GuaranteedStop
        {
            get { return _GuaranteedStop; }
            set
            {
                if (_GuaranteedStop != value)
                {
                    _GuaranteedStop = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _OrderType;
        public string OrderType
        {
            get { return _OrderType; }
            set
            {
                if (_OrderType != value)
                {
                    _OrderType = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _StopDistance;
        public decimal? StopDistance
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

        private decimal? _LimitDistance;
        public decimal? LimitDistance
        {
            get { return _LimitDistance; }
            set
            {
                if (_LimitDistance != value)
                {
                    _LimitDistance = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _CurrencyCode;
        public string CurrencyCode
        {
            get { return _CurrencyCode; }
            set
            {
                if (_CurrencyCode != value)
                {
                    _CurrencyCode = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _InstrumentName;
        public string InstrumentName
        {
            get { return _InstrumentName; }
            set
            {
                if (_InstrumentName != value)
                {
                    _InstrumentName = value;
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

        private string _MarketStatus;
        public string MarketStatus
        {
            get { return _MarketStatus; }
            set
            {
                if (_MarketStatus != value)
                {
                    _MarketStatus = value;
                    OnPropertyChanged();
                }
            }
        }        
    }
}
