using IGTrading.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTrading.Data
{
    public interface ICustomOrderRepository
    {
        void Insert(CustomOrder customOrder);
        IEnumerable<CustomOrder> GetAll();
    }
}
