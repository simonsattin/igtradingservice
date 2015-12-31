using IGPublicPcl;
using IGTradeManager.UI.Data;
using IGTradeManager.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class AccountService : IAccountService
    {
        private readonly IGStreamingApiClient _StreamClient;
        private readonly IgRestApiClient _IGApi;
        private readonly IDataCache _DataCache;

        public AccountService(IDataCache dataCache)
        {
            _IGApi = new IgRestApiClient();
            _StreamClient = new IGStreamingApiClient();
            _DataCache = dataCache;
        }

        public bool Login(string apiKey, string username, string password)
        {
            // use v2 secure login...			
            var ar = new dto.colibri.endpoint.auth.v2.AuthenticationRequest();
            ar.identifier = username;
            ar.password = password;

            var response = _IGApi.SecureAuthenticate(ar, apiKey);
            var result = response.Result;            

            if (result == null || result.Response == null || result.Response.accounts.Count == 0)
                return false;

            //get account details
            _DataCache.AccountId = result.Response.accounts[0].accountId;
            _DataCache.AccountName = result.Response.accounts[0].accountName;
            _DataCache.Balance = result.Response.accountInfo.balance;
            _DataCache.ProfitAndLoss = result.Response.accountInfo.profitLoss;
            _DataCache.Deposit = result.Response.accountInfo.deposit;
            _DataCache.Available = result.Response.accountInfo.available;

            //connect to lightstream
            var conversationContext = _IGApi.GetConversationContext();

            return true;
        }

        public void LoadWorkingOrders()
        {
            var currentIGWorkingOrders = _IGApi.workingOrdersV2().Result.Response.workingOrders;

            foreach (var item in currentIGWorkingOrders)
            {
                _DataCache.IgWorkingOrders.Add(new IgWorkingOrder()
                {
                    Epic = item.marketData.epic,
                    DealId = item.workingOrderData.dealId,
                    Direction = item.workingOrderData.direction,
                    OrderSize = item.workingOrderData.orderSize,
                    OrderLevel = item.workingOrderData.orderLevel,
                    TimeInForce = item.workingOrderData.timeInForce,
                    GoodTillDate = item.workingOrderData.goodTillDate,
                    CreatedDate = item.workingOrderData.createdDate,
                    GuaranteedStop = item.workingOrderData.guaranteedStop,
                    OrderType = item.workingOrderData.orderType,
                    StopDistance = item.workingOrderData.stopDistance,
                    LimitDistance = item.workingOrderData.limitDistance,
                    CurrencyCode = item.workingOrderData.currencyCode,
                    InstrumentName = item.marketData.instrumentName,
                    Expiry = item.marketData.expiry,
                    MarketStatus = item.marketData.marketStatus
                });
            }
        }


        public void Logout()
        {
            _IGApi.logout();

            _StreamClient.disconnect();
        }
    }
}
