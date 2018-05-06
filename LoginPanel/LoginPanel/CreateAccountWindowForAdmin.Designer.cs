namespace LoginPanel
{
    partial class CreateAccountWindowForAdmin
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
            this.signUpUserControl1 = new LoginPanel.SignUpUserControl();
            this.SuspendLayout();
            // 
            // signUpUserControl1
            // 
            this.signUpUserControl1.Location = new System.Drawing.Point(1, 2);
            this.signUpUserControl1.Margin = new System.Windows.Forms.Padding(5);
            this.signUpUserControl1.Name = "signUpUserControl1";
            this.signUpUserControl1.Size = new System.Drawing.Size(544, 374);
            this.signUpUserControl1.TabIndex = 4;
            // 
            // CreateAccountWindowForAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 353);
            this.Controls.Add(this.signUpUserControl1);
            this.Name = "CreateAccountWindowForAdmin";
            this.Text = "CreateAccountWindowForAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private SignUpUserControl signUpUserControl1;
    }
}