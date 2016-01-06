using IGTradeManager.UI.Data;
using IGTradeManager.UI.Data.DataAccess;
using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class OrdersService : IOrdersService
    {
        private readonly IDataCache _DataCache;
        private readonly IDataAccess _DataAccess;

        public OrdersService(IDataCache dataCache, IDataAccess dataAccess)
        {
            _DataAccess = dataAccess;
            _DataCache = dataCache;
        }

        public void LoadDatabaseOrders()
        {
            //fill database orders
            var databaseOrders = _DataAccess.GetDatabaseOrders();
            foreach (var item in databaseOrders)
            {
                _DataCache.DatabaseOrders.Add(item);
            }
        }

        public void DeleteDatabaseOrder(DatabaseOrder order)
        {
            //delete from database
            _DataAccess.DeleteDatabaseOrder(order);

            //remove from cache
            _DataCache.DatabaseOrders.Remove(_DataCache.DatabaseOrders.First(o => o.Id == order.Id));
            
            //unsubscribe from lightstreamer
                    
        }

        public void InsertDatabaseOrder(DatabaseOrder order)
        {
            //add to database
            _DataAccess.InsertDatabaseOrder(order);

            //add to cache
            _DataCache.DatabaseOrders.Add(order);

            //subscribe to market listener

        }


        public void UpdateDatabaseOrder(DatabaseOrder order)
        {
            _DataAccess.SaveDatabaseOrder(order);

            ////reload orders
            //_DataCache.DatabaseOrders.Clear();
            //var databaseOrders = _DataAccess.GetDatabaseOrders();
            //foreach (var item in databaseOrders)
            //{
            //    _DataCache.DatabaseOrders.Add(item);
            //}
        }
    }
}
