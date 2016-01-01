using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.NewDatabaseOrder
{
    public interface INewDatabaseOrderViewModel : IController
    {
        string Name { get; }
        string Ticker { get; }
        string IgInstrumentName { get; }
        string Expiry { get; }
        DateTime NextEarnings { get; }
        decimal BreakoutLevel { get; }
        decimal StopDistance { get; }

        void InsertDatabaseOrder();
    }
}
