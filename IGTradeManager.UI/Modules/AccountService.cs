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
        private AuthenticationResponse _LastResponse;

        private readonly IDataCache _DataCache;
        private readonly IAccountDataCache _AccountDataCache;
        private readonly IMarketUpdateSubscription _MarketSubscription;
        private readonly IAccountUpdateSubscription _AccountUpdateSubscription;
        private readonly ITradeUpdateSubscription _TradeUpdateSubscription;
        private readonly IHeartbeatUpdateSubscription _HeartbeatUpdateSubscription;

        public AccountService(IDataCache dataCache, IAccountDataCache accountDataCache, IMarketUpdateSubscription marketSubscription, 
            IAccountUpdateSubscription accountUpdateSubscription, ITradeUpdateSubscription tradeUpdateSubscription, IHeartbeatUpdateSubscription heartbeatUpdateSubscription)
        {
            _IGApi = new IgRestApiClient();
            _StreamClient = new IGStreamingApiClient();

            _DataCache = dataCache;
            _AccountDataCache = accountDataCache;
            _MarketSubscription = marketSubscription;
            _AccountUpdateSubscription = accountUpdateSubscription;
            _TradeUpdateSubscription = tradeUpdateSubscription;
            _HeartbeatUpdateSubscription = heartbeatUpdateSubscription;

            _MarketSubscription.MarketSubscriptionTick += _MarketSubscription_MarketSubscriptionTick;
            _AccountUpdateSubscription.AccountSubscriptionUpdate += _AccountUpdateSubscription_AccountSubscriptionUpdate;
            _TradeUpdateSubscription.TradeSubscriptionUpdate += _TradeUpdateSubscription_TradeSubscriptionUpdate;
            _HeartbeatUpdateSubscription.HeartbeatUpdate += _HeartbeatUpdateSubscription_HeartbeatUpdate;            
        }

        private void _HeartbeatUpdateSubscription_HeartbeatUpdate(HeartbeatUpdateEventArgs e)
        {
            _DataCache.HeartbeatUpdate = e.HeartbeatLastUpdated;
        }

        private void _TradeUpdateSubscription_TradeSubscriptionUpdate(TradeSubscriptionUpdateEventArgs e)
        {
            
        }

        private void _AccountUpdateSubscription_AccountSubscriptionUpdate(AccountSubscriptionUpdateEventArgs e)
        {
            _AccountDataCache.ProfitAndLoss = e.PNL;
            _AccountDataCache.Margin = e.UsedMargin;
            _AccountDataCache.Equity = e.Equity;
            _AccountDataCache.Funds = e.Funds;           
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
            _AccountDataCache.AccountId = result.Response.accounts[0].accountId;
            _AccountDataCache.AccountName = result.Response.accounts[0].accountName;
            _AccountDataCache.Balance = result.Response.accountInfo.balance;
            _AccountDataCache.ProfitAndLoss = result.Response.accountInfo.profitLoss;
            _AccountDataCache.Deposit = result.Response.accountInfo.deposit;
            _AccountDataCache.Available = result.Response.accountInfo.available;                       

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
                    InstrumentName = item.marketData.instrumentName,
                    Expiry = item.marketData.expiry,
                    MarketStatus = item.marketData.marketStatus,
                    InstrumentType = item.marketData.instrumentType,
                    LotSize = item.marketData.lotSize,
                    High = item.marketData.high,
                    Low = item.marketData.low,
                    PercentageChange = item.marketData.percentageChange,
                    NetChange = item.marketData.netChange,
                    Bid = item.marketData.bid,
                    Offer = item.marketData.offer,
                    UpdateTime = item.marketData.updateTime,
                    DelayTime = item.marketData.delayTime,
                    StreamingPricesAvailable = item.marketData.streamingPricesAvailable,
                    ScalingFactor = item.marketData.scalingFactor,

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
                    DMA = item.workingOrderData.dma              
                });
            }
        }

        public decimal? GetMinimumDealSizeForEpic(string epic)
        {
            var response = _IGApi.marketDetailsV2(epic);
            var result = response.Result;         

            if (result == null || result.Response == null || result.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            return result.Response.dealingRules.minDealSize.value;
        }

        public void LoadOpenPositions()
        {
            var openPositions = _IGApi.getOTCOpenPositionsV2().Result.Response.positions;

            foreach (var position in openPositions)
            {                                                                 
                _DataCache.IgOpenPositions.Add(new IgOpenPosition()
                {
                    Epic = position.market.epic,
                    InstrumentName = position.market.instrumentName,
                    Expiry = position.market.expiry,
                    MarketStatus = position.market.marketStatus,
                    InstrumentType = position.market.instrumentType,
                    LotSize = position.market.lotSize,
                    High = position.market.high,
                    Low  = position.market.low,
                    PercentageChange = position.market.percentageChange,
                    NetChange = position.market.netChange,
                    Bid = position.market.bid,
                    Offer = position.market.offer,
                    UpdateTime = position.market.updateTime,
                    DelayTime = position.market.delayTime,
                    StreamingPricesAvailable = position.market.streamingPricesAvailable,
                    ScalingFactor = position.market.scalingFactor,
                    
                    ContractSize = position.position.contractSize,
                    CreatedDate = position.position.createdDate,
                    DealId = position.position.dealId,
                    Size = position.position.size,
                    Direction = position.position.direction,
                    LimitLevel = position.position.limitLevel,
                    Level = position.position.level,
                    Currency = position.position.currency,
                    ControlledRisk = position.position.controlledRisk,
                    StopLevel = position.position.stopLevel,
                    TrailingStep = position.position.trailingStep,
                    TrailingStopDistance = position.position.trailingStopDistance
                });
            }
        }

        public void FillMinimumDealSizeForDatabaseOrders()
        {
            foreach (var order in _DataCache.DatabaseOrders)
            {
                var minimumdealsize = GetMinimumDealSizeForEpic(order.IgInstrument);

                order.MinimumDealSize = minimumdealsize;
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

            //account updates
            _StreamClient.subscribeToAccountDetails(_LastResponse.currentAccountId, _AccountUpdateSubscription);

            //heartbeat
            _StreamClient.subscribeToHeartbeatTradeSubscription(_HeartbeatUpdateSubscription);

            //trade - positions/orders/confirms updates
            _StreamClient.subscribeToTradeSubscription(_LastResponse.currentAccountId, _TradeUpdateSubscription);

            return true;
        }

        public void SubscribeDatabaseOrderToMarketListener(DatabaseOrder order)
        {
            var key = _StreamClient.subscribeToMarketDetails(new string[] { order.IgInstrument }, _MarketSubscription);
        }

        public void Logout()
        {
            //_IGApi.logout();

            _StreamClient.disconnect();
        }
    }        
}
