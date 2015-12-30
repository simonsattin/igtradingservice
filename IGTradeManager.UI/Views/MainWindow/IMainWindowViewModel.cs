using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGTradeManager.UI.Views.MainWindow
{
    public interface IMainWindowViewModel : IController
    {
        void Login();

        void Logout();

        string AccountId { get; set; }
        string AccountName { get; set; }
        decimal? Balance { get; set; }
    }
}
