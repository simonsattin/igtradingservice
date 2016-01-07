using IGTradeManager.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class DatabaseOrder : DependancyObject
    {
        public DatabaseOrder()
        {
            PropertyChanged += DatabaseOrder_PropertyChanged;
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

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    OnPropertyChanged();
                }
            }
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

        private string _IgInstrument;
        public string IgInstrument
        {
            get { return _IgInstrument; }
            set
            {
                if (_IgInstrument != value)
                {
                    _IgInstrument = value;
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

        private decimal _Bid;
        public decimal Bid
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

        private decimal _Ask;
        public decimal Ask
        {
            get { return _Ask; }
            set
            {
                if (_Ask != value)
                {
                    _Ask = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _ChangePercent;
        public decimal ChangePercent
        {
            get { return _ChangePercent; }
            set
            {
                if (_ChangePercent != value)
                {
                    _ChangePercent = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _EntryLevel;
        public decimal EntryLevel
        {
            get { return _EntryLevel; }
            set
            {
                if (_EntryLevel != value)
                {
                    _EntryLevel = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _PercentFromEntry;
        public decimal PercentFromEntry
        {
            get { return _PercentFromEntry; }
            set
            {
                if (_PercentFromEntry != value)
                {
                    _PercentFromEntry = value;
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

        private decimal _PositionSize;
        public decimal PositionSize
        {
            get { return _PositionSize; }
            set
            {
                if (_PositionSize != value)
                {
                    _PositionSize = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal _SpreadPercentOfRisk;
        public decimal SpreadPercentOfRisk
        {
            get { return _SpreadPercentOfRisk; }
            set
            {
                if (_SpreadPercentOfRisk != value)
                {
                    _SpreadPercentOfRisk = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _LastUpdateTime;
        public DateTime LastUpdateTime
        {
            get { return _LastUpdateTime; }
            set
            {
                if (_LastUpdateTime != value)
                {
                    _LastUpdateTime = value;
                    OnPropertyChanged();
                }
            }
        }

        private void DatabaseOrder_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SpreadToApply" || e.PropertyName == "Bid" || e.PropertyName == "Ask" || e.PropertyName == "BreakoutLevel")
            {
                CalculateEntryLevel();
            }

            if (e.PropertyName == "EntryLevel" || e.PropertyName == "Ask")
            {
                CalculatePercentFromEntry();
            }

            if (e.PropertyName == "RiskPerTrade" || e.PropertyName == "StopDistance")
            {
                CalculatePositionSize();
            }

            if (e.PropertyName == "Bid" || e.PropertyName == "Ask" || e.PropertyName == "StopDistance")
            {
                CalcualteSpreadAsPercentageOfRisk();
            }
        }

        private void CalculatePercentFromEntry()
        {
            if (Ask > 0 && EntryLevel > 0)
            {
                PercentFromEntry = Math.Round(((Ask - EntryLevel) / EntryLevel) * 100, 2);
            }
        }

        private void CalculateEntryLevel()
        {
            if (Bid > 0 && Ask > 0 && SpreadToApply > 0)
            {
                EntryLevel = ((Ask - Bid) * (SpreadToApply/100)) + BreakoutLevel;
            }
        }

        private void CalculatePositionSize()
        {
            if (RiskPerTrade > 0 && StopDistance > 0)
            {
                PositionSize = Math.Round(RiskPerTrade / StopDistance, 1);
            }
        }

        private void CalcualteSpreadAsPercentageOfRisk()
        {
            if (Bid > 0 && Ask > 0 && StopDistance > 0)
            {
                SpreadPercentOfRisk = Math.Round((Ask - Bid) / StopDistance, 2);
            }
        }

    }
}
