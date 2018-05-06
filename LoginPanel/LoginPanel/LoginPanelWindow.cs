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
    public partial class LoginPanelWindow : Form
    {
        public LoginPanelWindow()
        {
            InitializeComponent();

            // początkowe menu
            panelCurrentMenu.Height = buttonLogin.Height;
            panelCurrentMenu.Top = buttonLogin.Top;
            loginUserControl1.BringToFront();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // zmień położenie czerwonego panelu, by było wiadomo które menu (login lub rejestracja) jest teraz otwarte
            panelCurrentMenu.Height = buttonLogin.Height;
            panelCurrentMenu.Top = buttonLogin.Top; // czemu bez tego nie działa?

            // pokaż wszystkie kontrolki dla zalogowania
            loginUserControl1.BringToFront();


        }
        
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            // zmień położenie czerwonego panelu, by było wiadomo które menu (login lub rejestracja) jest teraz otwarte
            panelCurrentMenu.Height = buttonSignUp.Height;
            panelCurrentMenu.Top = buttonSignUp.Top;

            // pokaż kontrolki dla rejestracji
            signUpUserControl1.BringToFront();
        }

        // wyjście z aplikacji
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // minimalizacja
        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        //
        // Window drag and drop
        // source: https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
        //

        private bool mouseDown;
        private Point lastLocation;

        private void window_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void window_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                Location = new Point(
                    (Location.X - lastLocation.X) + e.X, (Location.Y - lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void window_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
