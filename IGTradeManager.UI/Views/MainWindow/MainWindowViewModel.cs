using IGTradeManager.UI.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.MainWindow
{
    public class MainWindowViewModel : IMainWindowViewModel
    {
        private readonly IAccountService _AccountService;

        public MainWindowViewModel(IAccountService accountService)
        {
            _AccountService = accountService;
        }

        public void Login()
        {
            _AccountService.Login();
        }
    }
}
