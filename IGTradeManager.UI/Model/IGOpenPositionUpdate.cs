using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class IGOpenPositionUpdate : DependancyObject
    {
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

        private string _DealIdOrigin;
        public string DealIdOrigin
        {
            get { return _DealIdOrigin; }
            set
            {
                if (_DealIdOrigin != value)
                {
                    _DealIdOrigin = value;
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

        private DateTime _Timestamp;
        public DateTime Timestamp
        {
            get { return _Timestamp; }
            set
            {
                if (_Timestamp != value)
                {
                    _Timestamp = value;
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

        private string _Status;
        public string Status
        {
            get { return _Status; }
            set
            {
                if (_Status != value)
                {
                    _Status = value;
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

        private string _DealReference;
        public string DealReference
        {
            get { return _DealReference; }
            set
            {
                if (_DealReference != value)
                {
                    _DealReference = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _DealStatus;
        public string DealStatus
        {
            get { return _DealStatus; }
            set
            {
                if (_DealStatus != value)
                {
                    _DealStatus = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _Channel;
        public string Channel
        {
            get { return _Channel; }
            set
            {
                if (_Channel != value)
                {
                    _Channel = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
