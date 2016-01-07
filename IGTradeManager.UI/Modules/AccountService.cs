using dto.colibri.endpoint.auth.v2;
using IGPublicPcl;
using IGTradeManager.UI.Data;
using IGTradeManager.UI.Model;
using IGTradeManager.UI.Modules.IgLightStreamerSubscriptions;
using Lightstreamer.DotNet.Client;
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
        private AuthenticationResponse _LastResponse;
        private readonly IMarketUpdateSubscription _MarketSubscription;
        private readonly IAccountUpdateSubscription _AccountUpdateSubscription;

        public AccountService(IDataCache dataCache, IMarketUpdateSubscription marketSubscription, IAccountUpdateSubscription accountUpdateSubscription)
        {
            _IGApi = new IgRestApiClient();
            _StreamClient = new IGStreamingApiClient();
            _DataCache = dataCache;
            _MarketSubscription = new MarketUpdateSubscription();
            _AccountUpdateSubscription = new AccountUpdateSubscription();

            _MarketSubscription.MarketSubscriptionTick += _MarketSubscription_MarketSubscriptionTick;
            _AccountUpdateSubscription.AccountSubscriptionUpdate += _AccountUpdateSubscription_AccountSubscriptionUpdate;
        }

        private void _AccountUpdateSubscription_AccountSubscriptionUpdate(AccountSubscriptionUpdateEventArgs e)
        {
            
        }

        private void _MarketSubscription_MarketSubscriptionTick(MarketSubscriptionTickEventArgs e)
        {
            var matchingOrder = _DataCache.DatabaseOrders.FirstOrDefault(o => e.Ticker.Contains(o.IgInstrument));
            if (matchingOrder != null)
            {
                matchingOrder.Bid = e.Bid;
                matchingOrder.Ask = e.Offer;
                matchingOrder.ChangePercent = e.ChangePercent;
                matchingOrder.Status = e.MarketState;
                matchingOrder.LastUpdateTime = e.UpdateTime;
            }
        }

        public bool Login(string apiKey, string username, string password)
        {
            // use v2 secure login...			
            var ar = new dto.colibri.endpoint.auth.v2.AuthenticationRequest();
            ar.identifier = username;
            ar.password = password;

            var response = _IGApi.SecureAuthenticate(ar, apiKey);
            var result = response.Result;
            _LastResponse = result.Response;        

            if (result == null || result.Response == null || result.Response.accounts.Count == 0)
                return false;

            //get account details
            _DataCache.AccountId = result.Response.accounts[0].accountId;
            _DataCache.AccountName = result.Response.accounts[0].accountName;
            _DataCache.Balance = result.Response.accountInfo.balance;
            _DataCache.ProfitAndLoss = result.Response.accountInfo.profitLoss;
            _DataCache.Deposit = result.Response.accountInfo.deposit;
            _DataCache.Available = result.Response.accountInfo.available;                       

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

        public void LoadIgOpenPositions()
        {
            var openPositions = _IGApi.getOTCOpenPositionsV2().Result.Response.positions;

            foreach (var position in openPositions)
            {                
                _DataCache.IgOpenPositions.Add(new IgOpenPosition()
                {
                    
                });
            }
        }

        public bool ConnectToLightStreamer()
        {
            var conversationContext = _IGApi.GetConversationContext();

            //connect to light streamer
            if (!_StreamClient.Connect(
                _LastResponse.currentAccountId,
                conversationContext.cst,
                conversationContext.xSecurityToken,
                conversationContext.apiKey,
                _LastResponse.lightstreamerEndpoint))
            {
                return false;
            }

            _StreamClient.subscribeToAccountDetails(_LastResponse.currentAccountId, _AccountUpdateSubscription);

            return true;
        }

        public void SubscribeDatabaseOrderToMarketListener(DatabaseOrder order)
        {
            var key = _StreamClient.subscribeToMarketDetails(new string[] { order.IgInstrument }, _MarketSubscription);
        }

        public void Logout()
        {
            _IGApi.logout();

            _StreamClient.disconnect();
        }
    }        
}
