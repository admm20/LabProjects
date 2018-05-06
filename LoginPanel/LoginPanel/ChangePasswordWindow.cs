using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class ChangePasswordWindow : Form
    {
        private int accountId = -1;

        public ChangePasswordWindow()
        {
            InitializeComponent();
        }
        
        public ChangePasswordWindow(int accountId)
        {
            InitializeComponent();

            this.accountId = accountId;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            AccountManagement am = new AccountManagement();

            am.ChangePassword(accountId, passwordBox.Text);

            this.Close(); // wylacz okno
        }
    }
}
