﻿using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public interface IAccountService
    {
        bool Login(string apiKey, string username, string password);
        void Logout();
        void LoadWorkingOrders();
        void LoadOpenPositions();
        bool ConnectToLightStreamer();
        void SubscribeDatabaseOrderToMarketListener(DatabaseOrder order);
        decimal? GetMinimumDealSizeForEpic(string epic);
        void FillMinimumDealSizeForDatabaseOrders();
        void CreateWorkingOrder(DatabaseOrder order);
    }
}
