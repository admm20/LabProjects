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
    public partial class AdminWindow : Form
    {
        Dictionary<int, EventItem> availableEvents;


        public AdminWindow()
        {
            InitializeComponent();



        }

        // ten konstruktor jest wywoływany przy pokazaniu nowego okna administratora
        public AdminWindow(Account account)
        {
            InitializeComponent();
            label1.Text = "Logged as " + account.firstName + " " + account.lastName + " (" + account.email + ")";

            AccountList.SelectionMode = SelectionMode.One;
        }

        // klikniecie przycisku 'refresh'
        private void button1_Click(object sender, EventArgs e)
        {
            AccountManagement am = new AccountManagement();

            AccountList.BeginUpdate();
            AccountList.Items.Clear();
            foreach (Account acc in am.GetAllAccounts())
            {
                AccountList.Items.Add(acc.id + " - " + acc.login + " - " + acc.email + " - " + acc.type.ToString());
            }

            AccountList.EndUpdate();

        }

        // wybranie obiektu z listy
        private void AccountList_Click(object sender, EventArgs e)
        {


            if(AccountList.SelectedItem != null)
            {
                // Console.WriteLine("Wybrano " + AccountList.SelectedItem.ToString());
                AccountManagement am = new AccountManagement();
                availableEvents = am.GetEventMap();

                int id = getIdOfSelectedAccount();
                showUserEvents(id);
            }
        }

        // wyswietl wydarzenia dla danego konta
        private void showUserEvents(int id)
        {
            AccountManagement am = new AccountManagement();
            EventList.BeginUpdate();

            EventList.Items.Clear(); // wyczysc liste

            // wstaw do niej wszystkie wydarzenia uzytkownika
            foreach (EventRegistration er in am.GetEventRegistrationList(id))
            {
                EventItem eventItem = availableEvents[er.eventId];
                EventList.Items.Add(er.eventRegistrationId + " - " + 
                    eventItem.name + " - " + er.foodType + " - " + er.type + " - " + er.confirmation);
            }

            EventList.EndUpdate();
        }

        // przycisk 'add user'
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            Form newAccountWindow;
            newAccountWindow = new CreateAccountWindowForAdmin();
            newAccountWindow.Show();
        }

        // przycisk 'delete'
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // pobierz ID zaznaczonego obiektu
            int id = getIdOfSelectedAccount();
            if(id != -1)
            {
                AccountManagement am = new AccountManagement();
                am.DeleteAccountByID(id);

                AccountList.BeginUpdate();
                AccountList.Items.Remove(AccountList.SelectedItem);
                AccountList.EndUpdate();
            }
        }

        // wyciaganie id z zaznaczonego pola
        private int getIdOfSelectedAccount()
        {
            if (AccountList.SelectedItem != null)
            {
                string input = AccountList.SelectedItem.ToString();
                string output = new string(input.TakeWhile(char.IsDigit).ToArray());
                int id = Int32.Parse(output);
                return id;
            }
            else
                return -1;
        }

        // wyciaganie id z pola z wydarzeniami
        private int getIdOfSelectedEvent()
        {
            if (EventList.SelectedItem != null)
            {
                string input = EventList.SelectedItem.ToString();
                string output = new string(input.TakeWhile(char.IsDigit).ToArray());
                int id = Int32.Parse(output);
                return id;
            }
            else
                return -1;
        }

        // przycisk 'change password'
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            // pobierz ID zaznaczonego obiektu
            int id = getIdOfSelectedAccount();
            if (id != -1)
            {
                Form form = new ChangePasswordWindow(id);

                form.Show();
            }
        }

        // przycisk zatwierdzania zapisu
        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            int id = getIdOfSelectedEvent();
            if(id != -1){
                AccountManagement am = new AccountManagement();
                am.SetConfirmation(id, "yes");

                int accId = getIdOfSelectedAccount();
                showUserEvents(accId);
            }
        }

        // przycisk odrzucania zapisu
        private void RejectBtn_Click(object sender, EventArgs e)
        {
            int id = getIdOfSelectedEvent();
            if (id != -1)
            {
                AccountManagement am = new AccountManagement();
                am.SetConfirmation(id, "no");

                int accId = getIdOfSelectedAccount();
                showUserEvents(accId);
            }
        }
    }
}
