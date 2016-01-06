namespace IGTradeManager.UI.Views.NewDatabaseOrder
{
    partial class NewDatabaseOrderView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this._NameTextbox = new System.Windows.Forms.TextBox();
            this.DataContext = new IGTradeManager.UI.ThreadSafeBindingSource(this.components);
            this._TickerTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._IgInstrumentTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._ExpiryTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._InsertButton = new System.Windows.Forms.Button();
            this._NextEarningsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._BreakoutLevelNumeric = new System.Windows.Forms.NumericUpDown();
            this._StopDistanceNumeric = new System.Windows.Forms.NumericUpDown();
            this._ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BreakoutLevelNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._StopDistanceNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // _NameTextbox
            // 
            this._NameTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Name", true));
            this._NameTextbox.Location = new System.Drawing.Point(284, 49);
            this._NameTextbox.Name = "_NameTextbox";
            this._NameTextbox.Size = new System.Drawing.Size(459, 38);
            this._NameTextbox.TabIndex = 1;
            this._NameTextbox.Enter += new System.EventHandler(this._NameTextbox_Enter);
            this._NameTextbox.Validating += new System.ComponentModel.CancelEventHandler(this._NameTextbox_Validating);
            // 
            // DataContext
            // 
            this.DataContext.ControlToInvokeOn = this;
            this.DataContext.DataSource = typeof(IGTradeManager.UI.Views.NewDatabaseOrder.INewDatabaseOrderViewModel);
            // 
            // _TickerTextbox
            // 
            this._TickerTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Ticker", true));
            this._TickerTextbox.Location = new System.Drawing.Point(284, 133);
            this._TickerTextbox.Name = "_TickerTextbox";
            this._TickerTextbox.Size = new System.Drawing.Size(459, 38);
            this._TickerTextbox.TabIndex = 3;
            this._TickerTextbox.Enter += new System.EventHandler(this._TickerTextbox_Enter);
            this._TickerTextbox.Validating += new System.ComponentModel.CancelEventHandler(this._TickerTextbox_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ticker";
            // 
            // _IgInstrumentTextbox
            // 
            this._IgInstrumentTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "IgInstrumentName", true));
            this._IgInstrumentTextbox.Location = new System.Drawing.Point(284, 217);
            this._IgInstrumentTextbox.Name = "_IgInstrumentTextbox";
            this._IgInstrumentTextbox.Size = new System.Drawing.Size(459, 38);
            this._IgInstrumentTextbox.TabIndex = 5;
            this._IgInstrumentTextbox.Enter += new System.EventHandler(this._IgInstrumentTextbox_Enter);
            this._IgInstrumentTextbox.Validating += new System.ComponentModel.CancelEventHandler(this._IgInstrumentTextbox_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "IgInstrument";
            // 
            // _ExpiryTextbox
            // 
            this._ExpiryTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Expiry", true));
            this._ExpiryTextbox.Location = new System.Drawing.Point(284, 301);
            this._ExpiryTextbox.Name = "_ExpiryTextbox";
            this._ExpiryTextbox.Size = new System.Drawing.Size(459, 38);
            this._ExpiryTextbox.TabIndex = 7;
            this._ExpiryTextbox.Enter += new System.EventHandler(this._ExpiryTextbox_Enter);
            this._ExpiryTextbox.Validating += new System.ComponentModel.CancelEventHandler(this._ExpiryTextbox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Expiry";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Next Earnings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 472);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Breakout Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 556);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Stop Distance";
            // 
            // _InsertButton
            // 
            this._InsertButton.Location = new System.Drawing.Point(537, 638);
            this._InsertButton.Name = "_InsertButton";
            this._InsertButton.Size = new System.Drawing.Size(206, 61);
            this._InsertButton.TabIndex = 15;
            this._InsertButton.Text = "Insert";
            this._InsertButton.UseVisualStyleBackColor = true;
            this._InsertButton.Click += new System.EventHandler(this._InsertButton_Click);
            // 
            // _NextEarningsDateTimePicker
            // 
            this._NextEarningsDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DataContext, "NextEarnings", true));
            this._NextEarningsDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "NextEarnings", true));
            this._NextEarningsDateTimePicker.Location = new System.Drawing.Point(284, 388);
            this._NextEarningsDateTimePicker.Name = "_NextEarningsDateTimePicker";
            this._NextEarningsDateTimePicker.Size = new System.Drawing.Size(459, 38);
            this._NextEarningsDateTimePicker.TabIndex = 9;
            this._NextEarningsDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this._NextEarningsDateTimePicker_Validating);
            // 
            // _BreakoutLevelNumeric
            // 
            this._BreakoutLevelNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DataContext, "BreakoutLevel", true));
            this._BreakoutLevelNumeric.DecimalPlaces = 4;
            this._BreakoutLevelNumeric.Location = new System.Drawing.Point(284, 472);
            this._BreakoutLevelNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._BreakoutLevelNumeric.Name = "_BreakoutLevelNumeric";
            this._BreakoutLevelNumeric.Size = new System.Drawing.Size(459, 38);
            this._BreakoutLevelNumeric.TabIndex = 11;
            this._BreakoutLevelNumeric.Enter += new System.EventHandler(this._BreakoutLevelNumeric_Enter);
            this._BreakoutLevelNumeric.Validating += new System.ComponentModel.CancelEventHandler(this._BreakoutLevelNumeric_Validating);
            // 
            // _StopDistanceNumeric
            // 
            this._StopDistanceNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.DataContext, "StopDistance", true));
            this._StopDistanceNumeric.DecimalPlaces = 4;
            this._StopDistanceNumeric.Location = new System.Drawing.Point(284, 550);
            this._StopDistanceNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._StopDistanceNumeric.Name = "_StopDistanceNumeric";
            this._StopDistanceNumeric.Size = new System.Drawing.Size(459, 38);
            this._StopDistanceNumeric.TabIndex = 13;
            this._StopDistanceNumeric.Enter += new System.EventHandler(this._StopDistanceNumeric_Enter);
            this._StopDistanceNumeric.Validating += new System.ComponentModel.CancelEventHandler(this._StopDistanceNumeric_Validating);
            // 
            // _ErrorProvider
            // 
            this._ErrorProvider.ContainerControl = this;
            // 
            // NewDatabaseOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 733);
            this.Controls.Add(this._StopDistanceNumeric);
            this.Controls.Add(this._BreakoutLevelNumeric);
            this.Controls.Add(this._NextEarningsDateTimePicker);
            this.Controls.Add(this._InsertButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._ExpiryTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._IgInstrumentTextbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._TickerTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._NameTextbox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewDatabaseOrderView";
            this.Text = "NewDatabaseOrderView";
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BreakoutLevelNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._StopDistanceNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _NameTextbox;
        private System.Windows.Forms.TextBox _TickerTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _IgInstrumentTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _ExpiryTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button _InsertButton;
        private System.Windows.Forms.DateTimePicker _NextEarningsDateTimePicker;
        private System.Windows.Forms.NumericUpDown _BreakoutLevelNumeric;
        private System.Windows.Forms.NumericUpDown _StopDistanceNumeric;
        private ThreadSafeBindingSource DataContext;
        private System.Windows.Forms.ErrorProvider _ErrorProvider;
    }
}