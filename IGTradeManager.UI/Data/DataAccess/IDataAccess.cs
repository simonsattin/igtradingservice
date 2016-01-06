using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Data.DataAccess
{
    public interface IDataAccess
    {
        List<DatabaseOrder> GetDatabaseOrders();
        int SaveDatabaseOrder(DatabaseOrder order);
        int DeleteDatabaseOrder(DatabaseOrder order);
        int InsertDatabaseOrder(DatabaseOrder order);
    }
}
