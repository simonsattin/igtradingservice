using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public interface IOrdersService
    {
        void LoadDatabaseOrders();
        void DeleteDatabaseOrder(DatabaseOrder order);
        void UpdateDatabaseOrder(DatabaseOrder order);
        void InsertDatabaseOrder(DatabaseOrder order);
    }
}
