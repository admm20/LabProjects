using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginPanel
{
    struct EventInfo
    {
        public int id;
        public string name;
        public DateTime date;
        public string agenda;
    }

    class EventManagement
    {
        public EventManagement()
        {

        }

        public List<string> GetEventsList()
        {
            List<string> eventList = new List<string>();

            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT name FROM events";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    eventList.Add(reader.GetString(0));
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

            return eventList;
        }

        public EventInfo GetEventDetails(string eventName)
        {
            EventInfo evInf = new EventInfo();

            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "SELECT id, name, agenda, date FROM events WHERE name=@eventName";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@eventName", eventName);

                MySqlDataReader reader = cmd.ExecuteReader();

                // sprawdzanie każdej znalezionej krotki
                while (reader.Read())
                {
                    evInf.id = reader.GetInt32(0);
                    evInf.name = reader.GetString(1);
                    evInf.agenda = reader.GetString(2);
                    evInf.date = reader.GetDateTime(3);
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

            return evInf;
        }

        // zapisz uzytkownika na wydarzenie
        public void AddUserEvent(int userId, string foodType, int eventId, string type)
        {
            DbUtil db = new DbUtil();

            string connStr = db.getConnStr();

            MySqlConnection conn = null;

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();

                string query = "INSERT INTO zapisy VALUES (null, @userId, @foodType, @eventId, 'none', @type)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@foodType", foodType);
                cmd.Parameters.AddWithValue("@eventId", eventId);
                cmd.Parameters.AddWithValue("@type", type);

                int added = cmd.ExecuteNonQuery();

                Console.WriteLine("Rows added: " + added);

                DialogResult dialog = MessageBox.Show("Zapisano na wydarzenie", "Sukces");

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
