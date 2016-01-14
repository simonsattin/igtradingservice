using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public interface IFactory
    {
        DatabaseOrder CreateDatabaseOrder();
    }
}
