using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanel
{
    public enum AccountType
    {
        USER,
        ADMIN
    }

    public enum SignUpStatus
    {
        LOGIN_EXISTS,
        EMAIL_EXISTS,
        OK,
        CONNECTION_LOST
    }

    public enum LoginStatus
    {
        LOGIN_NOT_EXISTS,
        WRONG_PASSWORD,
        CONNECTION_LOST,
        OK
    }

    public class DbUtil
    {
        private static string connStr = "server=localhost;user=root;database=login_panel;port=3306;password=root";
        MySqlConnection conn = null;

        public DbUtil()
        {
        }

        public string getConnStr()
        {
            return connStr;
        }

        // dodanie uzytkownika do tabeli
        // zwraca SignUpStatus
        // w bazie danych nie może powtarzać się email albo login
        public SignUpStatus AddUser(Account account)
        {
            SignUpStatus status = SignUpStatus.OK;

            // Sprawdzenie, czy w bazie jest konto o takim samym loginie/emailu
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                // zapytanie powinno zwrócić wszystkich użytkowników, którzy mają taki sam login lub email
                string query = "SELECT login, email FROM accounts WHERE login=@login OR email=@email";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@login", account.login);
                cmd.Parameters.AddWithValue("@email", account.email);


                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    if (reader.GetString(1).Equals(account.email))
                    {
                        status = SignUpStatus.EMAIL_EXISTS;
                    }
                    else if (reader.GetString(0).Equals(account.login))
                    {
                        status = SignUpStatus.LOGIN_EXISTS;
                    }
                    
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                status = SignUpStatus.CONNECTION_LOST;
            }
            finally
            {
                conn.Close();
            }

            // jeżeli nie ma takiego uzytkownika w bazie, to go dodaj
            if (status.Equals(SignUpStatus.OK))
            {
                addRow(account);
            }

            return status;
        }

        // dodaj wiersz do tabeli bez sprawdzania, czy mozna dodac uzytkownika
        private void addRow(Account account)
        {
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "INSERT INTO accounts VALUES(null, @fname, @lname, @login, @pswd, @email, 'user')";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@fname", account.firstName);
                cmd.Parameters.AddWithValue("@lname", account.lastName);
                cmd.Parameters.AddWithValue("@login", account.login);
                cmd.Parameters.AddWithValue("@pswd", account.password);
                cmd.Parameters.AddWithValue("@email", account.email);

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        // Do metody podane zostaja: login, haslo i referencja do 'Account',
        // gdzie zostana zwrocone dane uzytkownika
        // Ponadto zwracany jest 'LoginStatus', ktory mowi np. z jakiego powodu nie mozna sie zalogowac
        public LoginStatus Login(string login, string password, out Account loggedAccount)
        {
            LoginStatus status = LoginStatus.OK;
            loggedAccount = null;

            // pobierz uzytkownika z bazy danych
            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                // zapytanie powinno zwrócić uzytkownika o podanym loginie
                string query = "SELECT * FROM accounts WHERE login=@login";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@login", login);
                
                MySqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    status = LoginStatus.LOGIN_NOT_EXISTS;
                }
                else
                {
                    // pobranie krotki 
                    while (reader.Read())
                    {
                        string pswd = reader.GetString(4); // (4 - kolumna 'password')
                        if (!pswd.Equals(password)) 
                        {
                            status = LoginStatus.WRONG_PASSWORD;
                        }
                        else // poprawny login i haslo
                        {
                            int accId = reader.GetInt32(0);
                            string fname = reader.GetString(1);
                            string lname = reader.GetString(2);
                            string mail = reader.GetString(5);

                            AccountType permission;
                            if (reader.GetValue(6).ToString().Equals("user"))
                            {
                                permission = AccountType.USER;
                            }
                            else
                            {
                                permission = AccountType.ADMIN;
                            }
                            loggedAccount = new Account(accId, fname, lname, login, password, mail, permission);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                status = LoginStatus.CONNECTION_LOST;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }



    }
}
