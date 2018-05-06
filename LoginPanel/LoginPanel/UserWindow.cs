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
    public partial class UserWindow : Form
    {
        private Account account;
        public UserWindow()
        {
            InitializeComponent();
        }

        public UserWindow(Account account)
        {
            InitializeComponent();
            this.account = account;
            labelWelcome.Text = "Logged as " + account.firstName + " " + account.lastName + " (" + account.email + ")";
        }

        // pobieranie eventow z bazy
        private void updateEventComboBox()
        {
            EventManagement em = new EventManagement();

            eventComboBox.BeginUpdate();
            eventComboBox.Items.Clear();
            foreach(string item in em.GetEventsList())
            {
                eventComboBox.Items.Add(item);
            }
            eventComboBox.EndUpdate();
        }

        // rozwiniecie comboboxa
        private void eventComboBox_DropDown(object sender, EventArgs e)
        {
            Console.WriteLine("rozwinieto");
            updateEventComboBox();
        }

        EventInfo ei;

        // wybor nowego eventu z comboboxa
        private void eventComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if(eventComboBox.SelectedItem != null)
            {
                EventManagement em = new EventManagement();

                ei = em.GetEventDetails(eventComboBox.SelectedItem.ToString());

                eventDate.Text = "Termin wydarzenia: \n" + ei.date.ToString();
                agendaTextBox.Text = ei.agenda;
            }


        }

        // zapisz wydarzenie
        private void saveEvent_Click(object sender, EventArgs e)
        {
            // jezeli podane zostaly wszystkie dane, to przypisz uzytkownikowi wydarzenie
            if (eventComboBox.SelectedItem != null 
                && PreferredFood.SelectedItem != null 
                && EventUserType.SelectedItem != null)
            {
                EventManagement em = new EventManagement();
                em.AddUserEvent(account.id, PreferredFood.SelectedItem.ToString(),
                    ei.id, EventUserType.SelectedItem.ToString());
                
            }
            else
            {
                Console.WriteLine("Nie wybrano wszystkich pól");
            }
        }
    }
}
