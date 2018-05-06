using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanel
{
    public class Account
    {
        public int id;
        public string firstName;
        public string lastName;
        public string login;
        public string password;
        public string email;
        public AccountType type;

        // na potrzeby rejestracji
        public Account(int id, string firstName, string lastName, string login, string password, string email, AccountType type)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.login = login;
            this.password = password;
            this.email = email;
            this.type = type;
        }

        // na potrzeby logowania
        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public Account()
        {

        }
    }
}
