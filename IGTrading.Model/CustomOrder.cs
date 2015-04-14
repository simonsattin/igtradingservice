using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTrading.Model
{
    public class CustomOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ticker { get; set; }
        public string IGEpic { get; set; }
        public DateTime Expiry { get; set; }
        public DateTime NextEarnings { get; set; }
        public decimal EntryLevel { get; set; }
        public decimal Risk { get; set; }
        public bool IsBuy { get; set; }
    }
}
