using dto.endpoint.workingorders.create.v2;
using IGPublicPcl;
using IGTrading.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradingService
{
    public class Looper
    {
        public void Run()
        {
            Console.WriteLine("Starting...");

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
                Console.WriteLine(string.Format("Logged in: {0} | {1} | {2}",
                    result.Response.accounts[0].accountId,
                    result.Response.accounts[0].accountName,
                    result.Response.accountInfo.balance));

                conversationContext = igRestApiClient.GetConversationContext();

                //get the orders from the database
                var repository = new SqlServerCustomOrderRepository();

                Console.WriteLine("Getting Order Sheet");

                var customOrders = repository.GetAll();

                Console.WriteLine(string.Format("Found {0} orders", customOrders.Count()));

                if (customOrders.Count() > 0)
                {
                    bool shouldContinue = true;

                    while (shouldContinue)
                    {
                        Console.WriteLine("Getting orders from IG");

                        var currentIGWorkingOrders = igRestApiClient.workingOrdersV2().Result.Response;

                        Console.WriteLine(string.Format("Found {0} IG orders", currentIGWorkingOrders.workingOrders.Count));

                        foreach (var customOrder in customOrders)
                        {
                            Console.WriteLine(string.Format("{0} @ {1}",
                                customOrder.Ticker,
                                customOrder.EntryLevel));

                            if (currentIGWorkingOrders.workingOrders.Any(o => o.workingOrderData.epic == customOrder.IGEpic))
                            {
                                Console.WriteLine("Already an order with IG");
                                continue;
                            }

                            Console.WriteLine("Getting latest IG data");

                            var igMarketData = igRestApiClient.marketDetailsV2(customOrder.IGEpic).Result.Response;

                            var bid = igMarketData.snapshot.bid;
                            var offer = igMarketData.snapshot.offer;

                            Console.WriteLine(string.Format("{0}/{1}", bid, offer));

                            var spreadAdjustment = ((offer - bid) * 0.6m);
                            var entryLevel = Math.Round(spreadAdjustment.Value + customOrder.EntryLevel, 1);
                            var percentFromEntry = Math.Round(((offer.Value - entryLevel) / entryLevel) * 100, 2);

                            Console.WriteLine(string.Format("{0}% from entry", percentFromEntry));

                            var positionSize = Math.Round(riskAmount / customOrder.Risk, 2);

                            Console.WriteLine(string.Format("Position Size: {0}", positionSize));

                            var relativeSpreadSize = Math.Round(((offer.Value - bid.Value) / customOrder.Risk) * 100, 2);

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

                        try
                        {
                            Console.WriteLine("Hit return Key to exit");
                            string cancel = Reader.ReadLine(10000);
                            shouldContinue = false;
                        }
                        catch (TimeoutException)
                        {

                        }
                    }
                }
                else
                {
                    Console.WriteLine("No orders so exiting");
                }
            }
            else
            {
                Console.Write(string.Format("Failed to login: {0} --> {1}", result.StatusCode, result.Response));
            }

            if (conversationContext != null)
            {
                Console.WriteLine("Logging out");
                igRestApiClient.logout();
            }

            Console.WriteLine("Exiting");
            Console.ReadLine();
        }
    }
}
