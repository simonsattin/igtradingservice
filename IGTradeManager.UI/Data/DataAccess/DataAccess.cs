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
        private readonly IFactory _Factory;

        public DataAccess(IFactory factory)
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["AmazonConnection"].ConnectionString;
            _Factory = factory;
        }

        public List<DatabaseOrder> GetDatabaseOrders()
        {
            List<DatabaseOrder> orders = new List<DatabaseOrder>();

            using (var connection = new SqlConnection(_ConnectionString))
            {
                var databaseorders = connection.Query("select * from dbo.[Order]");
                foreach (var databaseorder in databaseorders)
                {
                    var order = _Factory.CreateDatabaseOrder();
                    order.Name = databaseorder.Name.Trim();
                    order.Ticker = databaseorder.Ticker.Trim();
                    order.IgInstrument = databaseorder.IgInstrument.Trim();
                    order.Expiry = databaseorder.Expiry.Trim();
                    order.NextEarnings = databaseorder.NextEarnings;
                    order.BreakoutLevel = databaseorder.BreakoutLevel;
                    order.StopDistance = databaseorder.StopDistance;

                    orders.Add(order);
                }                
            }

            return orders;
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

        public int InsertDatabaseOrder(DatabaseOrder order)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                string sql = @"
INSERT INTO [dbo].[Order]
           ([Name]
           ,[Ticker]
           ,[IgInstrument]
           ,[Expiry]
           ,[NextEarnings]
           ,[BreakoutLevel]
           ,[StopDistance])
VALUES (@Name, @Ticker, @IgInstrument, @Expiry, @NextEarnings, @BreakoutLevel, @StopDistance)
";

                return connection.Execute(sql, order);
            }
        }

        public int DeleteDatabaseOrder(DatabaseOrder order)
        {
            using (var connection = new SqlConnection(_ConnectionString))
            {
                string sql = @"DELETE FROM dbo.[Order] WHERE Id = @Id";

                return connection.Execute(sql, order);
            }
        }
    }
}
