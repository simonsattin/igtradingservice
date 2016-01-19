using IGTradeManager.UI.Model;
using IGTradeManager.UI.Views.NewDatabaseOrder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGTradeManager.UI.Views.MainWindow
{
    public partial class MainWindowView : BaseForm
    {
        private IMainWindowViewModel _ViewModel;

        public MainWindowView()
        {
            this.ClientSize = new Size(500, 300);

            InitializeComponent();

            //this.Size = this.ClientSize;

            this.ClientSize = new Size(2484, 1425);

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

            Thread.Sleep(1000);
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
            _Tabs.SelectedIndex = 0;

            var dialog = new NewDatabaseOrderView();
            dialog.ShowDialog();            
        }

        private void _DatabaseOrdersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Name" || senderGrid.Columns[e.ColumnIndex].HeaderText == "Ticker" ||
                    senderGrid.Columns[e.ColumnIndex].HeaderText == "Expiry" || senderGrid.Columns[e.ColumnIndex].HeaderText == "IgInstrument" ||
                    senderGrid.Columns[e.ColumnIndex].HeaderText == "NextEarnings" || senderGrid.Columns[e.ColumnIndex].HeaderText == "BreakoutLevel" ||
                    senderGrid.Columns[e.ColumnIndex].HeaderText == "StopDistance")
                {
                    var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;
                    _ViewModel.UpdateDatabaseOrder(order);
                }
            }
        }

        private void _DatabaseOrdersGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex].HeaderText == "Status")
            {
                var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;

                switch (order.Status)
                {
                    case "CLOSED":
                    case "OFFLINE":
                    case "SUSPENDED":
                        e.CellStyle.BackColor = Color.Red;
                        break;
                    case "TRADEABLE":
                        e.CellStyle.BackColor = Color.Green;
                        break;
                    case "AUCTION":
                    case "AUCTION_NO_EDIT":
                    case "EDIT":
                        e.CellStyle.BackColor = Color.Yellow;
                        break;                    
                    default:
                        e.CellStyle.BackColor = Color.Empty;
                        break;
                }
            }

            if (senderGrid.Columns[e.ColumnIndex].HeaderText == "PositionSize")
            {
                var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;

                e.CellStyle.BackColor = (order.IsPositionSizeBelowMinimumDealSize) ? Color.Red : Color.Green;
                return;
            }

            if (senderGrid.Columns[e.ColumnIndex].HeaderText == "SpreadPercentOfRisk")
            {
                var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;

                e.CellStyle.BackColor = (order.IsSpreadPercentOfRiskWithinParamter) ? Color.Green : Color.Red;
                return;
            }

            if (senderGrid.Columns[e.ColumnIndex].Name == "ChangePercent")
            {
                var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;

                if (order.ChangePercent == 0)
                {
                    e.CellStyle.BackColor = Color.Empty;
                    return;
                }

                if (order.ChangePercent > 0)
                {
                    e.CellStyle.BackColor = Color.Green;
                    return;
                }

                if (order.ChangePercent < 0)
                {
                    e.CellStyle.BackColor = Color.Red;
                    return;
                }
            }

            if (senderGrid.Columns[e.ColumnIndex].Name == "PercentFromEntry")
            {
                var order = _DatabaseOrdersGridView.Rows[e.RowIndex].DataBoundItem as DatabaseOrder;

                if (order.PercentFromEntry > 0)
                {
                    e.CellStyle.BackColor = Color.Orange;
                    return;
                }

                if (order.PercentFromEntry < 0 && order.PercentFromEntry > -5)
                {
                    e.CellStyle.BackColor = Color.Green;
                    return;
                }

                if (order.PercentFromEntry < -5)
                {
                    e.CellStyle.BackColor = Color.Red;
                    return;
                }                
            }
        }
    }
}
