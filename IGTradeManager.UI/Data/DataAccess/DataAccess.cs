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
    }
}
