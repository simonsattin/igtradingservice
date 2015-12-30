using IGPublicPcl;
using IGTradeManager.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private readonly IGStreamingApiClient _StreamClient;
        private readonly IgRestApiClient _IGApi;

        public MainWindowViewModel()
        {
            _StreamClient = new IGStreamingApiClient();
            _IGApi = new IgRestApiClient();
        }

        public void Login()
        {
            const string API_KEY = "fd3e7ec86cb96ad3d1e4aa13302ca9b14f337547";
            const string URL = "https://api.ig.com/gateway";
            const string USERNAME = "SHN22";
            const string PASSWORD = "darcyB#o?23";         

            // use v2 secure login...			
            var ar = new dto.colibri.endpoint.auth.v2.AuthenticationRequest();
            ar.identifier = USERNAME;
            ar.password = PASSWORD;

            var response = _IGApi.SecureAuthenticate(ar, API_KEY);
            var result = response.Result;

            ConversationContext conversationContext = null;

            if (result && (result.Response != null) && (result.Response.accounts.Count > 0))
            {
                var accountId = result.Response.accounts[0].accountId;

                AccountId = accountId;
                AccountName = result.Response.accounts[0].accountName;
                Balance = result.Response.accountInfo.balance;        

                conversationContext = _IGApi.GetConversationContext();
            }
        }

        public void Logout()
        {
            _IGApi.logout();
        }

        private string _AccountId;
        public string AccountId
        {
            get { return _AccountId; }
            set
            {
                if (_AccountId != value)
                {
                    _AccountId = value;
                    OnPropertyChanged();
                }        
            }
        }

        private string _AccountName;
        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                if (_AccountName != value)
                {
                    _AccountName = value;
                    OnPropertyChanged();
                }
            }
        }

        private decimal? _Balance;
        public decimal? Balance
        {
            get { return _Balance; }
            set
            {
                if (_Balance != value)
                {
                    _Balance = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
