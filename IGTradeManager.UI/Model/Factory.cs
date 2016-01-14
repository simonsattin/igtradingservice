using IGTradeManager.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Model
{
    public class Factory : IFactory
    {
        private readonly IRiskMetrics _RiskMetrics;

        public Factory(IRiskMetrics riskMetrics)
        {
            _RiskMetrics = riskMetrics;
        }

        public DatabaseOrder CreateDatabaseOrder()
        {
            var riskMetrics = ContainerProvider.Container.GetInstance<IRiskMetrics>();
            return new DatabaseOrder(riskMetrics);
        }
    }
}
