using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class IgWorkingOrder : DependancyObject
    {
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

        private string _InstrumentType;
        public string InstrumentType
        {
            get { return _InstrumentType; }
            set
            {
                if (_InstrumentType != value)
                {
                    _InstrumentType = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _LotSize;
        public decimal? LotSize
        {
            get { return _LotSize; }
            set
            {
                if (_LotSize != value)
                {
                    _LotSize = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _High;
        public decimal? High
        {
            get { return _High; }
            set
            {
                if (_High != value)
                {
                    _High = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Low;
        public decimal? Low
        {
            get { return _Low; }
            set
            {
                if (_Low != value)
                {
                    _Low = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _PercentageChange;
        public decimal? PercentageChange
        {
            get { return _PercentageChange; }
            set
            {
                if (_PercentageChange != value)
                {
                    _PercentageChange = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _NetChange;
        public decimal? NetChange
        {
            get { return _NetChange; }
            set
            {
                if (_NetChange != value)
                {
                    _NetChange = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Bid;
        public decimal? Bid
        {
            get { return _Bid; }
            set
            {
                if (_Bid != value)
                {
                    _Bid = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Offer;
        public decimal? Offer
        {
            get { return _Offer; }
            set
            {
                if (_Offer != value)
                {
                    _Offer = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _UpdateTime;
        public string UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                if (_UpdateTime != value)
                {
                    _UpdateTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _DelayTime;
        public int DelayTime
        {
            get { return _DelayTime; }
            set
            {
                if (_DelayTime != value)
                {
                    _DelayTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _StreamingPricesAvailable;
        public bool StreamingPricesAvailable
        {
            get { return _StreamingPricesAvailable; }
            set
            {
                if (_StreamingPricesAvailable != value)
                {
                    _StreamingPricesAvailable = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _ScalingFactor;
        public int ScalingFactor
        {
            get { return _ScalingFactor; }
            set
            {
                if (_ScalingFactor != value)
                {
                    _ScalingFactor = value;
                    OnPropertyChanged();
                }
            }
        }


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

        private bool _DMA;
        public bool DMA
        {
            get { return _DMA; }
            set
            {
                if (_DMA != value)
                {
                    _DMA = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
