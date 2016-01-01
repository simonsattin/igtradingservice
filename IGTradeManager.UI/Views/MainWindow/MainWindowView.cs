using IGTradeManager.UI.Model;
using IGTradeManager.UI.Views.NewDatabaseOrder;
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

        private void MainWindowView_FormClosed(object sender, FormClosedEventArgs e)
        {
            _ViewModel.Logout();
        }

        private void _DatabaseOrdersGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;
                    _ViewModel.DeleteDatabaseOrder(order);
                }
            }
        }       

        private void _AddOrderButton_Click(object sender, EventArgs e)
        {
            var dialog = new NewDatabaseOrderView();
            dialog.ShowDialog();
        }

        private void _DatabaseOrdersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
