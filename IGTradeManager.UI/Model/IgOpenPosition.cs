using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class IgOpenPosition : DependancyObject
    {
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
    }
}
