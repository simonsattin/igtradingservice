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
            // MainWindowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1789, 1226);
            this.Controls.Add(this._LoginButton);
            this.Name = "MainWindowView";
            this.Text = "MainWindowView";
            ((System.ComponentModel.ISupportInitialize)(this.DataContext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _LoginButton;
        private ThreadSafeBindingSource DataContext;
    }
}