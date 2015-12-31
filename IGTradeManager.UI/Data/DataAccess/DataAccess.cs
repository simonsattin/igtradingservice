using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using IGTradeManager.UI.Model;

namespace IGTradeManager.UI.Data.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string _ConnectionString;

        public DataAccess()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["AmazonConnection"].ConnectionString;
        }

        public List<DatabaseOrder> GetOrders()
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                return connection.Query<DatabaseOrder>("select * from dbo.[Order]").ToList();
            }
        }

        public int SaveDatabaseOrder(DatabaseOrder order)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                string sql = @"
UPDATE dbo.[Order]
set Name = @Name,
    Ticker = @Ticker,
    IgInstrument = @IgInstrument,
    Expiry = @Expiry,
    NextEarnings = @NextEarnings,
    BreakoutLevel = @BreakoutLevel,
    StopDistance = @StopDistance
WHERE Id = @Id
";

                return connection.Execute(sql, order);
            }
        }

        public int DeleteDatabaseOrder(int id)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                string sql = @"DELETE FROM dbo.[Order] WHERE Id = @Id";

                return connection.Execute(sql, id);
            }
        }
    }
}
