using IGPublicPcl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Modules
{
    public class AccountService : IAccountService
    {
        public void Login()
        {
            const string API_KEY = "fd3e7ec86cb96ad3d1e4aa13302ca9b14f337547";
            const string URL = "https://api.ig.com/gateway";
            const string USERNAME = "SHN22";
            const string PASSWORD = "darcyB#o?23";

            IgRestApiClient igRestApiClient = new IgRestApiClient();

            // use v2 secure login...			
            var ar = new dto.colibri.endpoint.auth.v2.AuthenticationRequest();
            ar.identifier = USERNAME;
            ar.password = PASSWORD;

            var response = igRestApiClient.SecureAuthenticate(ar, API_KEY);
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
            }
        }
    }
}
