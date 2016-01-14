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
        private readonly object _IgOpenPositionsLock = new object();

        public DataCache()
        {
            _DatabaseOrders = new BindingList<DatabaseOrder>();
            _IgWorkingOrders = new BindingList<IgWorkingOrder>();
            _IgOpenPositions = new BindingList<IgOpenPosition>();
        }

        private BindingList<IgOpenPosition> _IgOpenPositions;
        public BindingList<IgOpenPosition> IgOpenPositions
        {
            get { lock (_IgOpenPositionsLock) { return _IgOpenPositions; } }
            private set
            {
                lock (_IgOpenPositionsLock)
                {
                    if (_IgOpenPositions != value)
                    {
                        _IgOpenPositions = value;
                        OnPropertyChanged();
                    }
                }
            }
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

        private DateTime _HeartbeatUpdate;
        public DateTime HeartbeatUpdate
        {
            get
            {
                return _HeartbeatUpdate;
            }
            set
            {
                if (_HeartbeatUpdate != value)
                {
                    _HeartbeatUpdate = value;
                    OnPropertyChanged();
                }
            }
        }                 

        public void Reset()
        {
            DatabaseOrders.Clear();
            IgWorkingOrders.Clear();
            IgOpenPositions.Clear();
        }   
    }
}
