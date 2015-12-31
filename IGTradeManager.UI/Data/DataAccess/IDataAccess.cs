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
        List<DatabaseOrder> GetOrders();
        int SaveDatabaseOrder(DatabaseOrder order);
        int DeleteDatabaseOrder(int id);  
    }
}
