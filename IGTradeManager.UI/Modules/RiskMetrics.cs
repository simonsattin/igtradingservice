using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class RiskMetrics : DependancyObject, IRiskMetrics
    {
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

        private decimal _MaxSpreadPercent;
        public decimal MaxSpreadPercent
        {
            get
            {
                return _MaxSpreadPercent;
            }
            set
            {
                if (_MaxSpreadPercent != value)
                {
                    _MaxSpreadPercent = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
