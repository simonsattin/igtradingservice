using IGTrading.Model;
using System;
using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IGTrading.Data.SqlServer
{
    public class SqlServerCustomOrderRepository : ICustomOrderRepository
    {
        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["igtradingapp"].ConnectionString);
        }

        public void Insert(CustomOrder customOrder)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "insert into CustomOrder (Name, Ticker, IGEpic, Expiry, NextEarnings, EntryLevel, Risk)"
                    + "values(@Name, @Ticker, @IGEpic, @Expiry, @NextEarnings, @EntryLevel, @Risk)";

                connection.Execute(query, new 
                { 
                    customOrder.Name, 
                    customOrder.Ticker, 
                    customOrder.IGEpic, 
                    customOrder.Expiry, 
                    customOrder.NextEarnings, 
                    customOrder.EntryLevel, 
                    customOrder.Risk 
                });
            }
        }

        public IEnumerable<CustomOrder> GetAll()
        {
            using (SqlConnection connection = GetConnection())
            {
                var result = connection.Query<CustomOrder>("select * from CustomOrder");
                return result;
            }
        }
    }
}
