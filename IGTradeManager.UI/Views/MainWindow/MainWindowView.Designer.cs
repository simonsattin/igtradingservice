﻿namespace IGTradeManager.UI.Views.MainWindow
{
    partial class MainWindowView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._LoginButton = new System.Windows.Forms.Button();
            this.DataContext = new IGTradeManager.UI.ThreadSafeBindingSource(this.components);
            this._LogoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._AccountIdLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._AccountNameLabel = new System.Windows.Forms.Label();
            this._BalanceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._ProfitAndLossLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._ApiKeyTextbox = new System.Windows.Forms.TextBox();
            this._UsernameTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._PasswordTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._AvailableLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this._DatabaseOrdersGridView = new System.Windows.Forms.DataGridView();
            this.databaseOrdersBindingSource = new IGTradeManager.UI.ThreadSafeBindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tickerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.igInstrumentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextEarningsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.breakoutLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.askDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entryLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentFromEntryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stopDistanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spreadPercentOfRiskDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._DatabaseOrdersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOrdersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _LoginButton
            // 
            this._LoginButton.Location = new System.Drawing.Point(41, 35);
            this._LoginButton.Name = "_LoginButton";
            this._LoginButton.Size = new System.Drawing.Size(253, 60);
            this._LoginButton.TabIndex = 0;
            this._LoginButton.Text = "LOGIN";
            this._LoginButton.UseVisualStyleBackColor = true;
            this._LoginButton.Click += new System.EventHandler(this._LoginButton_Click);
            // 
            // DataContext
            // 
            this.DataContext.ControlToInvokeOn = this;
            this.DataContext.DataSource = typeof(IGTradeManager.UI.Views.MainWindow.IMainWindowViewModel);
            // 
            // _LogoutButton
            // 
            this._LogoutButton.Location = new System.Drawing.Point(344, 35);
            this._LogoutButton.Name = "_LogoutButton";
            this._LogoutButton.Size = new System.Drawing.Size(253, 60);
            this._LogoutButton.TabIndex = 1;
            this._LogoutButton.Text = "LOGOUT";
            this._LogoutButton.UseVisualStyleBackColor = true;
            this._LogoutButton.Click += new System.EventHandler(this._LogoutButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Id:";
            // 
            // _AccountIdLabel
            // 
            this._AccountIdLabel.AutoSize = true;
            this._AccountIdLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "AccountId", true));
            this._AccountIdLabel.Location = new System.Drawing.Point(201, 193);
            this._AccountIdLabel.Name = "_AccountIdLabel";
            this._AccountIdLabel.Size = new System.Drawing.Size(93, 32);
            this._AccountIdLabel.TabIndex = 3;
            this._AccountIdLabel.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Account Name:";
            // 
            // _AccountNameLabel
            // 
            this._AccountNameLabel.AutoSize = true;
            this._AccountNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "AccountName", true));
            this._AccountNameLabel.Location = new System.Drawing.Point(574, 193);
            this._AccountNameLabel.Name = "_AccountNameLabel";
            this._AccountNameLabel.Size = new System.Drawing.Size(93, 32);
            this._AccountNameLabel.TabIndex = 5;
            this._AccountNameLabel.Text = "label2";
            // 
            // _BalanceLabel
            // 
            this._BalanceLabel.AutoSize = true;
            this._BalanceLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Balance", true));
            this._BalanceLabel.Location = new System.Drawing.Point(957, 193);
            this._BalanceLabel.Name = "_BalanceLabel";
            this._BalanceLabel.Size = new System.Drawing.Size(93, 32);
            this._BalanceLabel.TabIndex = 7;
            this._BalanceLabel.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance:";
            // 
            // _ProfitAndLossLabel
            // 
            this._ProfitAndLossLabel.AutoSize = true;
            this._ProfitAndLossLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "ProfitAndLoss", true));
            this._ProfitAndLossLabel.Location = new System.Drawing.Point(1413, 193);
            this._ProfitAndLossLabel.Name = "_ProfitAndLossLabel";
            this._ProfitAndLossLabel.Size = new System.Drawing.Size(93, 32);
            this._ProfitAndLossLabel.TabIndex = 9;
            this._ProfitAndLossLabel.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1199, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(212, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Profit and Loss:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 32);
            this.label2.TabIndex = 10;
            this.label2.Text = "API Key:";
            // 
            // _ApiKeyTextbox
            // 
            this._ApiKeyTextbox.Location = new System.Drawing.Point(181, 132);
            this._ApiKeyTextbox.Name = "_ApiKeyTextbox";
            this._ApiKeyTextbox.Size = new System.Drawing.Size(610, 38);
            this._ApiKeyTextbox.TabIndex = 11;
            this._ApiKeyTextbox.Text = "fd3e7ec86cb96ad3d1e4aa13302ca9b14f337547";
            // 
            // _UsernameTextbox
            // 
            this._UsernameTextbox.Location = new System.Drawing.Point(982, 132);
            this._UsernameTextbox.Name = "_UsernameTextbox";
            this._UsernameTextbox.Size = new System.Drawing.Size(215, 38);
            this._UsernameTextbox.TabIndex = 13;
            this._UsernameTextbox.Text = "SHN22";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(823, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Username:";
            // 
            // _PasswordTextbox
            // 
            this._PasswordTextbox.Location = new System.Drawing.Point(1440, 132);
            this._PasswordTextbox.Name = "_PasswordTextbox";
            this._PasswordTextbox.Size = new System.Drawing.Size(215, 38);
            this._PasswordTextbox.TabIndex = 15;
            this._PasswordTextbox.Text = "darcyB#o?23";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1281, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(147, 32);
            this.label7.TabIndex = 14;
            this.label7.Text = "Password:";
            // 
            // _AvailableLabel
            // 
            this._AvailableLabel.AutoSize = true;
            this._AvailableLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Available", true));
            this._AvailableLabel.Location = new System.Drawing.Point(1767, 193);
            this._AvailableLabel.Name = "_AvailableLabel";
            this._AvailableLabel.Size = new System.Drawing.Size(93, 32);
            this._AvailableLabel.TabIndex = 17;
            this._AvailableLabel.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1609, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 32);
            this.label10.TabIndex = 16;
            this.label10.Text = "Available:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Deposit", true));
            this.label8.Location = new System.Drawing.Point(2090, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 32);
            this.label8.TabIndex = 19;
            this.label8.Text = "label2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1932, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 32);
            this.label9.TabIndex = 18;
            this.label9.Text = "Deposit:";
            // 
            // _DatabaseOrdersGridView
            // 
            this._DatabaseOrdersGridView.AllowUserToAddRows = false;
            this._DatabaseOrdersGridView.AllowUserToDeleteRows = false;
            this._DatabaseOrdersGridView.AllowUserToResizeRows = false;
            this._DatabaseOrdersGridView.AutoGenerateColumns = false;
            this._DatabaseOrdersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._DatabaseOrdersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._DatabaseOrdersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.tickerDataGridViewTextBoxColumn,
            this.igInstrumentDataGridViewTextBoxColumn,
            this.expiryDataGridViewTextBoxColumn,
            this.nextEarningsDataGridViewTextBoxColumn,
            this.breakoutLevelDataGridViewTextBoxColumn,
            this.bidDataGridViewTextBoxColumn,
            this.askDataGridViewTextBoxColumn,
            this.entryLevelDataGridViewTextBoxColumn,
            this.percentFromEntryDataGridViewTextBoxColumn,
            this.stopDistanceDataGridViewTextBoxColumn,
            this.positionSizeDataGridViewTextBoxColumn,
            this.spreadPercentOfRiskDataGridViewTextBoxColumn});
            this._DatabaseOrdersGridView.DataSource = this.databaseOrdersBindingSource;
            this._DatabaseOrdersGridView.Location = new System.Drawing.Point(41, 321);
            this._DatabaseOrdersGridView.Name = "_DatabaseOrdersGridView";
            this._DatabaseOrdersGridView.RowTemplate.Height = 40;
            this._DatabaseOrdersGridView.Size = new System.Drawing.Size(2570, 418);
            this._DatabaseOrdersGridView.TabIndex = 20;
            this._DatabaseOrdersGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._DatabaseOrdersGridView_CellValueChanged);
            // 
            // databaseOrdersBindingSource
            // 
            this.databaseOrdersBindingSource.ControlToInvokeOn = this;
            this.databaseOrdersBindingSource.DataMember = "DatabaseOrders";
            this.databaseOrdersBindingSource.DataSource = this.DataContext;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 253);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(238, 32);
            this.label11.TabIndex = 21;
            this.label11.Text = "Database Orders:";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // tickerDataGridViewTextBoxColumn
            // 
            this.tickerDataGridViewTextBoxColumn.DataPropertyName = "Ticker";
            this.tickerDataGridViewTextBoxColumn.HeaderText = "Ticker";
            this.tickerDataGridViewTextBoxColumn.Name = "tickerDataGridViewTextBoxColumn";
            // 
            // igInstrumentDataGridViewTextBoxColumn
            // 
            this.igInstrumentDataGridViewTextBoxColumn.DataPropertyName = "IgInstrument";
            this.igInstrumentDataGridViewTextBoxColumn.HeaderText = "IgInstrument";
            this.igInstrumentDataGridViewTextBoxColumn.Name = "igInstrumentDataGridViewTextBoxColumn";
            // 
            // expiryDataGridViewTextBoxColumn
            // 
            this.expiryDataGridViewTextBoxColumn.DataPropertyName = "Expiry";
            this.expiryDataGridViewTextBoxColumn.HeaderText = "Expiry";
            this.expiryDataGridViewTextBoxColumn.Name = "expiryDataGridViewTextBoxColumn";
            // 
            // nextEarningsDataGridViewTextBoxColumn
            // 
            this.nextEarningsDataGridViewTextBoxColumn.DataPropertyName = "NextEarnings";
            this.nextEarningsDataGridViewTextBoxColumn.HeaderText = "NextEarnings";
            this.nextEarningsDataGridViewTextBoxColumn.Name = "nextEarningsDataGridViewTextBoxColumn";
            // 
            // breakoutLevelDataGridViewTextBoxColumn
            // 
            this.breakoutLevelDataGridViewTextBoxColumn.DataPropertyName = "BreakoutLevel";
            this.breakoutLevelDataGridViewTextBoxColumn.HeaderText = "BreakoutLevel";
            this.breakoutLevelDataGridViewTextBoxColumn.Name = "breakoutLevelDataGridViewTextBoxColumn";
            // 
            // bidDataGridViewTextBoxColumn
            // 
            this.bidDataGridViewTextBoxColumn.DataPropertyName = "Bid";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Red;
            this.bidDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.bidDataGridViewTextBoxColumn.HeaderText = "Bid";
            this.bidDataGridViewTextBoxColumn.Name = "bidDataGridViewTextBoxColumn";
            this.bidDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // askDataGridViewTextBoxColumn
            // 
            this.askDataGridViewTextBoxColumn.DataPropertyName = "Ask";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.askDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.askDataGridViewTextBoxColumn.HeaderText = "Ask";
            this.askDataGridViewTextBoxColumn.Name = "askDataGridViewTextBoxColumn";
            this.askDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // entryLevelDataGridViewTextBoxColumn
            // 
            this.entryLevelDataGridViewTextBoxColumn.DataPropertyName = "EntryLevel";
            this.entryLevelDataGridViewTextBoxColumn.HeaderText = "EntryLevel";
            this.entryLevelDataGridViewTextBoxColumn.Name = "entryLevelDataGridViewTextBoxColumn";
            // 
            // percentFromEntryDataGridViewTextBoxColumn
            // 
            this.percentFromEntryDataGridViewTextBoxColumn.DataPropertyName = "PercentFromEntry";
            this.percentFromEntryDataGridViewTextBoxColumn.HeaderText = "PercentFromEntry";
            this.percentFromEntryDataGridViewTextBoxColumn.Name = "percentFromEntryDataGridViewTextBoxColumn";
            this.percentFromEntryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stopDistanceDataGridViewTextBoxColumn
            // 
            this.stopDistanceDataGridViewTextBoxColumn.DataPropertyName = "StopDistance";
            this.stopDistanceDataGridViewTextBoxColumn.HeaderText = "StopDistance";
            this.stopDistanceDataGridViewTextBoxColumn.Name = "stopDistanceDataGridViewTextBoxColumn";
            // 
            // positionSizeDataGridViewTextBoxColumn
            // 
            this.positionSizeDataGridViewTextBoxColumn.DataPropertyName = "PositionSize";
            this.positionSizeDataGridViewTextBoxColumn.HeaderText = "PositionSize";
            this.positionSizeDataGridViewTextBoxColumn.Name = "positionSizeDataGridViewTextBoxColumn";
            this.positionSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // spreadPercentOfRiskDataGridViewTextBoxColumn
            // 
            this.spreadPercentOfRiskDataGridViewTextBoxColumn.DataPropertyName = "SpreadPercentOfRisk";
            this.spreadPercentOfRiskDataGridViewTextBoxColumn.HeaderText = "SpreadPercentOfRisk";
            this.spreadPercentOfRiskDataGridViewTextBoxColumn.Name = "spreadPercentOfRiskDataGridViewTextBoxColumn";
            this.spreadPercentOfRiskDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2640, 1197);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._DatabaseOrdersGridView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._AvailableLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._PasswordTextbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._UsernameTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._ApiKeyTextbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._ProfitAndLossLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._BalanceLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._AccountNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._AccountIdLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._LogoutButton);
            this.Controls.Add(this._LoginButton);
            this.Name = "MainWindowView";
            this.Text = "MainWindowView";
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._DatabaseOrdersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.databaseOrdersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _LoginButton;
        private ThreadSafeBindingSource DataContext;
        private System.Windows.Forms.Button _LogoutButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label _AccountIdLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _BalanceLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label _AccountNameLabel;
        private System.Windows.Forms.Label _ProfitAndLossLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _ApiKeyTextbox;
        private System.Windows.Forms.TextBox _UsernameTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _PasswordTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label _AvailableLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView _DatabaseOrdersGridView;
        private ThreadSafeBindingSource databaseOrdersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn uniqueIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tickerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn igInstrumentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextEarningsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn breakoutLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn askDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entryLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentFromEntryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stopDistanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn spreadPercentOfRiskDataGridViewTextBoxColumn;
    }
}