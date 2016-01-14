using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class IgOpenPosition : DependancyObject
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

        private decimal? _ContractSize;
        public decimal? ContractSize
        {
            get { return _ContractSize; }
            set
            {
                if (_ContractSize != value)
                {
                    _ContractSize = value;
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

        private decimal? _Size;
        public decimal? Size
        {
            get { return _Size; }
            set
            {
                if (_Size != value)
                {
                    _Size = value;
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

        private decimal? _LimitLevel;
        public decimal? LimitLevel
        {
            get { return _LimitLevel; }
            set
            {
                if (_LimitLevel != value)
                {
                    _LimitLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Level;
        public decimal? Level
        {
            get { return _Level; }
            set
            {
                if (_Level != value)
                {
                    _Level = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Currency;
        public string Currency
        {
            get { return _Currency; }
            set
            {
                if (_Currency != value)
                {
                    _Currency = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _ControlledRisk;
        public bool ControlledRisk
        {
            get { return _ControlledRisk; }
            set
            {
                if (_ControlledRisk != value)
                {
                    _ControlledRisk = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _StopLevel;
        public decimal? StopLevel
        {
            get { return _StopLevel; }
            set
            {
                if (_StopLevel != value)
                {
                    _StopLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _TrailingStep;
        public decimal? TrailingStep
        {
            get { return _TrailingStep; }
            set
            {
                if (_TrailingStep != value)
                {
                    _TrailingStep = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _TrailingStopDistance;
        public decimal? TrailingStopDistance
        {
            get { return _TrailingStopDistance; }
            set
            {
                if (_TrailingStopDistance != value)
                {
                    _TrailingStopDistance = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
