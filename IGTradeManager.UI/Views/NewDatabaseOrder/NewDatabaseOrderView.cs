using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IGTradeManager.UI.Views.NewDatabaseOrder
{
    public partial class NewDatabaseOrderView : BaseForm
    {
        private INewDatabaseOrderViewModel _ViewModel;

        public NewDatabaseOrderView()
        {
            InitializeComponent();
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return; //The controller cannot be fetched at design time because the program has not loaded the kernel.
            init();
        }

        private void init()
        {
            _ViewModel = GetController<INewDatabaseOrderViewModel>();

            DataContext.DataSource = _ViewModel;
        }

        private void _InsertButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                _ViewModel.InsertDatabaseOrder();

                DialogResult = DialogResult.OK;
            }            
        }

        private void _NameTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextbox(_NameTextbox,e);
        }

        private void _TickerTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextbox(_TickerTextbox,e);
        }

        private void _IgInstrumentTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextbox(_IgInstrumentTextbox,e);
        }

        private void _ExpiryTextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextbox(_ExpiryTextbox,e);
        }

        private void _BreakoutLevelNumeric_Validating(object sender, CancelEventArgs e)
        {
            if (_BreakoutLevelNumeric.Value == 0)
            {
                _ErrorProvider.SetError(_BreakoutLevelNumeric, "*");
                e.Cancel = true;
            }
            else
            {
                _ErrorProvider.SetError(_BreakoutLevelNumeric, "");
            }
        }

        private void _StopDistanceNumeric_Validating(object sender, CancelEventArgs e)
        {
            if (_StopDistanceNumeric.Value == 0)
            {
                _ErrorProvider.SetError(_StopDistanceNumeric, "*");
                e.Cancel = true;
            }
            else
            {
                _ErrorProvider.SetError(_StopDistanceNumeric, "");
            }
        }

        private void ValidateTextbox(TextBox textbox, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                _ErrorProvider.SetError(textbox, "*");
                e.Cancel = true;
            }
            else
            {
                _ErrorProvider.SetError(textbox, "");
            }
        }

        private void _NextEarningsDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (_NextEarningsDateTimePicker.Value <= DateTime.Today)
            {
                _ErrorProvider.SetError(_NextEarningsDateTimePicker, "*");
                e.Cancel = true;
            }
            else
            {
                _ErrorProvider.SetError(_NextEarningsDateTimePicker, "");
            }
        }
    }
}
