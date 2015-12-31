using IGPublicPcl;
using IGTradeManager.UI.Data;
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

        public void Logout()
        {
            _IGApi.logout();

            _StreamClient.disconnect();
        }
    }
}
