﻿using System;
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
            Container.RegisterSingle<IDataCache, DataCache>();
            
            Container.Verify();
        }
    }
}
