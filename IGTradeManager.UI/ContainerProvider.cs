using IGTradeManager.UI.Data;
using IGTradeManager.UI.Data.DataAccess;
using IGTradeManager.UI.Modules;
using IGTradeManager.UI.Views.MainWindow;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI
{
    internal class ContainerProvider
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);   

        public readonly static Container Container = new Container();

        public static void SetupContainer()
        {
            Container.RegisterSingleton<IDataCache, DataCache>();
            Container.RegisterSingleton<IDataAccess, DataAccess>();

            Container.RegisterSingleton<IAccountService, AccountService>();
            Container.RegisterSingleton<IMainWindowViewModel, MainWindowViewModel>();
            
            Container.Verify();
        }
    }
}
