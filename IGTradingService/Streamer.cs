using dto.endpoint.workingorders.create.v2;
using IGPublicPcl;
using IGTrading.Data.SqlServer;
using Lightstreamer.DotNet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradingService
{
    public class Streamer
    {
        public void Run()
        {
            Console.WriteLine("Starting...");

            Console.WriteLine("Enter amount fo risk per trade");

            var riskAmount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Logging into IG API");

            const string IgApiUsername = "SHN22";

            const string IgApiPassword = "darcyB#o?23";

            const string IgApiKey = "fd3e7ec86cb96ad3d1e4aa13302ca9b14f337547";

            IgRestApiClient igRestApiClient = new IgRestApiClient();

            // use v2 secure login...			
            var ar = new dto.colibri.endpoint.auth.v2.AuthenticationRequest();
            ar.identifier = IgApiUsername;
            ar.password = IgApiPassword;

            var response = igRestApiClient.SecureAuthenticate(ar, IgApiKey);
            var result = response.Result;

            ConversationContext conversationContext = null;

            if (result && (result.Response != null) && (result.Response.accounts.Count > 0))
            {
                var accountId = result.Response.accounts[0].accountId;

                Console.WriteLine(string.Format("Logged in: {0} | {1} | {2}",
                    result.Response.accounts[0].accountId,
                    result.Response.accounts[0].accountName,
                    result.Response.accountInfo.balance));

                conversationContext = igRestApiClient.GetConversationContext();
           
                IGStreamingApiClient streamClient = new IGStreamingApiClient();

                var connectedToLightStream = streamClient.Connect(response.Result.Response.currentAccountId,
                        conversationContext.cst,
                        conversationContext.xSecurityToken, conversationContext.apiKey,
                        response.Result.Response.lightstreamerEndpoint);

                if (connectedToLightStream)
                {
                    var customOrderRepository = new SqlServerCustomOrderRepository();

                    var customOrders = customOrderRepository.GetAll();

                    var epics = customOrders.Select(o => o.IGEpic);

                    var currentIGWorkingOrders = igRestApiClient.workingOrdersV2().Result.Response.workingOrders;
                    
                    var subscription = new MarketSubscription();

                    var accountSubscription = new AccountSubscription();

                    subscription.TickerUpdate += (ticker, bid, offer, status) =>
                    {
                        if (status == "TRADEABLE")
                        {
                            var customOrder = customOrders.SingleOrDefault(c => ticker.Contains(c.IGEpic));

                            if (!currentIGWorkingOrders.Exists(o => o.marketData.epic == customOrder.IGEpic))
                            {
                                //check paramters
                                Console.WriteLine(string.Format("{0}/{1}", bid, offer));

                                var spreadAdjustment = ((offer - bid) * 0.6m);
                                var entryLevel = Math.Round(spreadAdjustment + customOrder.EntryLevel, 1);
                                var percentFromEntry = Math.Round(((offer - entryLevel) / entryLevel) * 100, 2);

                                Console.WriteLine(string.Format("{0}% from entry", percentFromEntry));

                                var positionSize = Math.Round(riskAmount / customOrder.Risk, 2);

                                Console.WriteLine(string.Format("Position Size: {0}", positionSize));

                                var relativeSpreadSize = Math.Round(((offer - bid) / customOrder.Risk) * 100, 2);

                                Console.WriteLine(string.Format("Spread % of R: {0}", relativeSpreadSize));

                                if (relativeSpreadSize <= 30)
                                {
                                    if (percentFromEntry <= 5)
                                    {
                                        Console.WriteLine("Generating order");
                                        CreateWorkingOrderRequest orderRequest = new CreateWorkingOrderRequest()
                                        {
                                            epic = customOrder.IGEpic,
                                            expiry = customOrder.Expiry.ToString("MMM-yy").ToUpper(),
                                            direction = customOrder.IsBuy ? "BUY" : "SELL",
                                            size = positionSize,
                                            level = entryLevel,
                                            type = "STOP",
                                            currencyCode = "GBP",
                                            timeInForce = "GOOD_TILL_DATE",
                                            goodTillDate = DateTime.Today.ToString("yyyy/MM/dd 23:59:59"),
                                            guaranteedStop = false,
                                            stopDistance = customOrder.Risk,
                                        };

                                        var orderResponse = igRestApiClient.createWorkingOrderV2(orderRequest);

                                        Console.WriteLine(string.Format("DealReference: {0}", orderResponse.Result.Response.dealReference));

                                        //reget the IG working orders
                                        currentIGWorkingOrders = igRestApiClient.workingOrdersV2().Result.Response.workingOrders;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ignoring as too far from entry");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ignoring as spread too large");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Already have order with IG");
                            }
                        }
                        else
                        {
                            Console.WriteLine(string.Format("Ignoring as status {0} is not TRADEABLE", status));
                        }
                    };
                    
                    var streamerKey = streamClient.subscribeToMarketDetails(epics.ToArray(),subscription);

                    var accountSubscriptionKey = streamClient.subscribeToAccountDetailsKey(accountId, accountSubscription);
                    
                    Console.ReadLine();

                    streamClient.UnsubscribeTableKey(accountSubscriptionKey);
                    streamClient.UnsubscribeTableKey(streamerKey);
                    streamClient.disconnect();
                    igRestApiClient.logout();
                }
                else
                {
                    Console.Write(string.Format("Failed to login: {0} --> {1}", result.StatusCode, result.Response));
                }
            }
        }

        public class AccountSubscription : HandyTableListenerAdapter
        {
            public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
            {


                base.OnUpdate(itemPos, itemName, update);
            }
        }

        public class MarketSubscription : HandyTableListenerAdapter
        {
            public Action<string, decimal, decimal, string> TickerUpdate;

            public override void OnUpdate(int itemPos, string itemName, IUpdateInfo update)
            {
                string output = string.Format("Open: {0} | High: {1} | Low: {2} | Change: {3} | Change %: {4} | UpdateTime: {5} | Delay: {6} | Status: {7} | Bid: {8} | Offer: {9}",
                    update.GetNewValue("MID_OPEN"),
                    update.GetNewValue("HIGH"),
                    update.GetNewValue("LOW"),
                    update.GetNewValue("CHANGE"),
                    update.GetNewValue("CHANGE_PCT"),
                    update.GetNewValue("UPDATE_TIME"),
                    update.GetNewValue("MARKET_DELAY"),
                    update.GetNewValue("MARKET_STATE"),
                    update.GetNewValue("BID"),
                    update.GetNewValue("OFFER"));

                Console.WriteLine(itemName);
                Console.WriteLine(output);

                var ticker = itemName;
                var bid = Convert.ToDecimal(update.GetNewValue("BID"));
                var offer = Convert.ToDecimal(update.GetNewValue("OFFER"));
                var status = update.GetNewValue("MARKET_STATE");

                var handler = TickerUpdate;
                if (handler != null)
                {
                    handler(ticker, bid, offer, status);
                }
                
                base.OnUpdate(itemPos, itemName, update);
            }
        }
    }
}
