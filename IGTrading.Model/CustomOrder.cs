using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace IGTrading.Model
{
    public class CustomOrder : INotifyPropertyChanged
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    _Id = value;
                    NotifyPropertyChanged("Id");
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
                    NotifyPropertyChanged("Name");
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
                    NotifyPropertyChanged("Ticker");
                }
            }
        }
        private string _IGEpic;
        public string IGEpic
        {
            get { return _IGEpic; }
            set
            {
                if (_IGEpic != value)
                {
                    _IGEpic = value;
                    NotifyPropertyChanged("IGEpic");
                }
            }
        }
        private DateTime _Expiry;
        public DateTime Expiry
        {
            get { return _Expiry; }
            set
            {
                if (_Expiry != value)
                {
                    _Expiry = value;
                    NotifyPropertyChanged("Expiry");
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
                    NotifyPropertyChanged("NextEarnings");
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
                    NotifyPropertyChanged("EntryLevel");
                }
            }
        }
        private decimal _Risk;
        public decimal Risk
        {
            get { return _Risk; }
            set
            {
                if (_Risk != value)
                {
                    _Risk = value;
                    NotifyPropertyChanged("Risk");
                }
            }
        }
        private bool _IsBuy;
        public bool IsBuy
        {
            get { return _IsBuy; }
            set
            {
                if (_IsBuy != value)
                {
                    _IsBuy = value;
                    NotifyPropertyChanged("IsBuy");
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
                    NotifyPropertyChanged("Bid");
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
                    NotifyPropertyChanged("Ask");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
