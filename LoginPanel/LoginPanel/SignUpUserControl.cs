using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace LoginPanel
{
    public partial class SignUpUserControl : UserControl
    {
        public SignUpUserControl()
        {
            InitializeComponent();
            signUpStatusLabel.Text = "";
        }

        private void signUpButtonClicked(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string pswd = passwordtextBox.Text;
            string confirmPswd = confirmPasswordtextBox.Text;
            string fname = fnameTextBox.Text;
            string lname = lnameTextBox.Text;
            string mail = emailTextBox.Text;
            // sprawdzanie, czy ktores pole jest puste
            if ( login == "" 
                || pswd == "" 
                || confirmPswd == "" 
                || fname == "" 
                || lname == "" 
                || mail == "") // ale to brzydko wyglada
            {
                signUpStatusLabel.Text = "Every field must be filled";
            }
            else if(pswd != confirmPswd) // czy potwierdzono poprawnie haslo
            {
                signUpStatusLabel.Text = "Both passwords are not equal";
            }
            else if (!CheckMail(mail)) // sprawdzanie struktury maila (podobne do regexa)
            {
                signUpStatusLabel.Text = "Wrong mail address";
            }
            else 
            {
                // spróbuj dodać go do bazy
                DbUtil db = new DbUtil();
                SignUpStatus status = db.AddUser(
                    new Account(-1, fname, lname, login, 
                                pswd, mail, AccountType.USER)
                    );

                switch (status)
                {
                    case SignUpStatus.LOGIN_EXISTS:
                        signUpStatusLabel.Text = "User with this login name already exists";
                        break;
                    case SignUpStatus.EMAIL_EXISTS:
                        signUpStatusLabel.Text = "You already have account";
                        break;
                    case SignUpStatus.OK:
                        DialogResult dialog = MessageBox.Show("Created new account", "Success");
                        SendMail(mail);
                        signUpStatusLabel.Text = "";
                        break;
                    case SignUpStatus.CONNECTION_LOST:
                        signUpStatusLabel.Text = "Server is busy. Please try later.";
                        break;
                }
            }
        }

        // Wysyla maila potwierdzajacego rejestracje
        private void SendMail(string address)
        {
            SmtpClient smtpClient = new SmtpClient();

            // uzywamy niestandardowych opcji wysylania
            smtpClient.UseDefaultCredentials = false;

            // adres i haslo nadawcy
            NetworkCredential credential =
                new NetworkCredential("januszjanusz12213@wp.pl", "januszjanusz12213");

            // wiadomosc, ktora zostanie wyslana
            MailMessage message = new MailMessage();

            // adres nadawcy
            MailAddress fromAddress = new MailAddress("januszjanusz12213@wp.pl");

            // serwer poczty wychodzacej
            smtpClient.Host = "smtp.wp.pl";
            smtpClient.Credentials = credential;

            message.From = fromAddress;
            message.Subject = "Welcome new user!"; // tytul

            message.IsBodyHtml = true; // wiadomosc bedzie odczytana jako html
            message.Body = "<h1>Thank You for creating new account</h1>"; // tresc
            message.To.Add(address);

            try
            {
                smtpClient.Send(message); // wyslij wiadomosc
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); // tresc bledu
            }
        }

        // sprawdzanie emaila
        private bool CheckMail(string mail)
        {
            try
            {
                MailAddress address = new MailAddress(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // pokaz/ukryj haslo 
        private void showPasswordCheckboxClicked(object sender, EventArgs e)
        {
            if (showPasswordCheckbox.Checked)
            {
                passwordtextBox.UseSystemPasswordChar = false;
                confirmPasswordtextBox.UseSystemPasswordChar = false;
            }
            
            else
            {
                passwordtextBox.UseSystemPasswordChar = true;
                confirmPasswordtextBox.UseSystemPasswordChar = true;
            }
        }
    }
}
