using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    public partial class LoginUserControl : UserControl
    {
        private int wrongLoginAttempts = 0;

        public LoginUserControl()
        {
            InitializeComponent();
            loginStatusLabel.Text = ""; // na poczatku nie ma byc zadnego bledu logowania
        }

        // przycisk 'Login'
        private void button1_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;

            if (login == "")
            {
                loginStatusLabel.Text = "Field 'login' cannot be empty";
            }
            else if(password == "")
            {
                loginStatusLabel.Text = "Field 'password' cannot be empty";
            }
            else
            {
                DbUtil dbCon = new DbUtil();
                Account loggedAccount = null;
                LoginStatus status = dbCon.Login(login, password, out loggedAccount);

                switch (status)
                {
                    case LoginStatus.LOGIN_NOT_EXISTS:
                        loginStatusLabel.Text = "Wrong login";
                        break;
                    case LoginStatus.WRONG_PASSWORD:
                        {
                            loginStatusLabel.Text = "Wrong password";
                            wrongLoginAttempts++;
                            if (wrongLoginAttempts > 2)
                            {
                                loginStatusLabel.Text = "You entered wrong password 3 times";
                                button1.Enabled = false;
                            }
                        }
                        break;
                    case LoginStatus.CONNECTION_LOST:
                        loginStatusLabel.Text = "Server is busy. Please try later";
                        break;
                    case LoginStatus.OK:
                        loginStatusLabel.Text = "";
                        Form userForm;

                        if (loggedAccount.type.Equals(AccountType.USER))
                            userForm = new UserWindow(loggedAccount);
                        else
                            userForm = new AdminWindow(loggedAccount);
                        userForm.Show();
                        

                      
                        break;
                }

            }

        }

        private void showPasswordClicked(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                passwordTextBox.UseSystemPasswordChar = false;
            else
                passwordTextBox.UseSystemPasswordChar = true;

        }
    }
}
