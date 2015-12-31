using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGTradeManager.UI.Views.MainWindow
{
    public partial class MainWindowView : BaseForm
    {
        private IMainWindowViewModel _ViewModel;

        public MainWindowView()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return; //The controller cannot be fetched at design time because the program has not loaded the kernel.
            init();
        }

        private void init()
        {
            _ViewModel = GetController<IMainWindowViewModel>();

            DataContext.DataSource = _ViewModel;           
        }

        private void _LoginButton_Click(object sender, EventArgs e)
        {
            _ViewModel.Login(_ApiKeyTextbox.Text,_UsernameTextbox.Text,_PasswordTextbox.Text);
        }

        private void _LogoutButton_Click(object sender, EventArgs e)
        {
            _ViewModel.Logout();
        }

        private void _DatabaseOrdersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
