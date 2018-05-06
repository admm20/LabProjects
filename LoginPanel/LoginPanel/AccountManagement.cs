using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanel
{

    class AccountManagement
    {

        // pobiera z bazy wszystkie dostepne konta (bez hasla)
        public List<Account> GetAllAccounts()
        {
            List<Account> accountsList = new List<Account>();

            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                
                string query = "SELECT id, login, email, permissions FROM accounts";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    Account acc = new Account();

                    acc.id = reader.GetInt32(0);
                    acc.login = reader.GetString(1);
                    acc.email = reader.GetString(2);

                    if (reader.GetValue(3).Equals("admin"))
                    {
                        acc.type = AccountType.ADMIN;
                    }
                    else
                    {
                        acc.type = AccountType.USER;
                    }

                    accountsList.Add(acc);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return accountsList;
        }

        // usun konto o podanym ID
        public void DeleteAccountByID(int id)
        {
            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "DELETE FROM accounts WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", id);

                int deletedRows = cmd.ExecuteNonQuery();
                Console.WriteLine("Deleted rows: " + deletedRows);

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

        // zmiana hasla
        public void ChangePassword(int accountId, string newPassword)
        {
            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "UPDATE accounts SET password=@password WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", accountId);
                cmd.Parameters.AddWithValue("@password", newPassword);

                int updatedRows = cmd.ExecuteNonQuery();
                Console.WriteLine("Updated rows: " + updatedRows);

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

        // pobiera liste wydarzen, na ktore zapisala sie dana osoba
        public List<EventRegistration> GetEventRegistrationList(int accountId)
        {
            List<EventRegistration> list = new List<EventRegistration>();

            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT id, food_type, event_id, type, confirmation FROM zapisy WHERE user_id=@accId";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@accId", accountId);

                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    EventRegistration acc = new EventRegistration();

                    acc.eventRegistrationId = reader.GetInt32(0);
                    acc.foodType = reader.GetString(1);
                    acc.eventId = reader.GetInt32(2);
                    acc.type = reader.GetString(3);
                    acc.confirmation = reader.GetString(4);
                    acc.accountId = accountId;

                    list.Add(acc);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return list;
        }

        // pobiera słownik, w którym kluczem jest id eventu, a wartością są informacje o tym evencie
        public Dictionary<int, EventItem> GetEventMap()
        {
            Dictionary<int, EventItem> dict = new Dictionary<int, EventItem>();

            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT id, name, agenda, date FROM events";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    EventItem ev = new EventItem();

                    ev.id = reader.GetInt32(0);
                    ev.name = reader.GetString(1);
                    ev.agenda = reader.GetString(2);
                    ev.date = reader.GetDateTime(3);

                    dict.Add(ev.id, ev);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dict;
        }

        public void SetConfirmation(int zapisId, string confirmationText)
        {
            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "UPDATE zapisy SET confirmation=@text WHERE id=@zapisId";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@text", confirmationText);
                cmd.Parameters.AddWithValue("@zapisId", zapisId);

                int changed = cmd.ExecuteNonQuery();

                Console.WriteLine("Changed rows: " + changed);
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
    }
}
