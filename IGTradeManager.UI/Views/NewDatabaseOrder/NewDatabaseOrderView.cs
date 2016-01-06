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

                _NameTextbox.Clear();
                _TickerTextbox.Clear();
                _IgInstrumentTextbox.Clear();
                _ExpiryTextbox.Clear();
                _NextEarningsDateTimePicker.Value = DateTime.Today;
                _BreakoutLevelNumeric.Value = 0;
                _StopDistanceNumeric.Value = 0;

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

        private void _NameTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _NameTextbox.SelectAll(); });
        }

        private void _TickerTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _TickerTextbox.SelectAll(); });
        }

        private void _IgInstrumentTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _IgInstrumentTextbox.SelectAll(); });
        }

        private void _ExpiryTextbox_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _ExpiryTextbox.SelectAll(); });
        }

        private void _BreakoutLevelNumeric_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _BreakoutLevelNumeric.Select(0, _BreakoutLevelNumeric.Text.Length); });
        }

        private void _StopDistanceNumeric_Enter(object sender, EventArgs e)
        {
            BeginInvoke((Action)delegate { _StopDistanceNumeric.Select(0, _StopDistanceNumeric.Text.Length); });
        }
    }
}
