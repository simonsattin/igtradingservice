namespace IGTradeManager.UI.Views.MainWindow
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
            this._LoginButton = new System.Windows.Forms.Button();
            this.DataContext = new IGTradeManager.UI.ThreadSafeBindingSource(this.components);
            this._LogoutButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._AccountIdLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._AccountNameLabel = new System.Windows.Forms.Label();
            this._BalanceLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(35, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account Id:";
            // 
            // _AccountIdLabel
            // 
            this._AccountIdLabel.AutoSize = true;
            this._AccountIdLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "AccountId", true));
            this._AccountIdLabel.Location = new System.Drawing.Point(201, 120);
            this._AccountIdLabel.Name = "_AccountIdLabel";
            this._AccountIdLabel.Size = new System.Drawing.Size(93, 32);
            this._AccountIdLabel.TabIndex = 3;
            this._AccountIdLabel.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Account Name:";
            // 
            // _AccountNameLabel
            // 
            this._AccountNameLabel.AutoSize = true;
            this._AccountNameLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "AccountName", true));
            this._AccountNameLabel.Location = new System.Drawing.Point(574, 120);
            this._AccountNameLabel.Name = "_AccountNameLabel";
            this._AccountNameLabel.Size = new System.Drawing.Size(93, 32);
            this._AccountNameLabel.TabIndex = 5;
            this._AccountNameLabel.Text = "label2";
            // 
            // _BalanceLabel
            // 
            this._BalanceLabel.AutoSize = true;
            this._BalanceLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.DataContext, "Balance", true));
            this._BalanceLabel.Location = new System.Drawing.Point(957, 120);
            this._BalanceLabel.Name = "_BalanceLabel";
            this._BalanceLabel.Size = new System.Drawing.Size(93, 32);
            this._BalanceLabel.TabIndex = 7;
            this._BalanceLabel.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(811, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Balance:";
            // 
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 1226);
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
    }
}