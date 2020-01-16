using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
{
    public class MySqlDb
    {
        private MySqlConnection conn;

        public MySqlDb(string server, string user, string pw, string db) {
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pw,
                Database = db,
                OldGuids = true
            };

            string connstr = connStringBuilder.ConnectionString;
            conn = new MySqlConnection(connstr);
        }

        public void OpenConnection() {
            conn.Open();
        }

        public void CloseConnection() {
            conn.Close();
        }

        public List<Ship> GetAllShips() {
            List<Ship> ships = new List<Ship>();
            string sql = "SELECT * FROM ships";
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read()) {
                    ships.Add(new Ship { 
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Registration = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return ships;
        }

        // In class - Add method to get a single ship

        // Homework four: models and method to print out a complete roster
        //      Crew member's full name, age and the role they fill, the ship's name and registration number
        public List<Roster> FullRoster()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                OpenConnection();
            }
            List<Roster> result = new List<Roster>();
            string sql = "select c.fname, c.lname, c.age, rol.role, s.name, s.registration "
                + "from crew as c "
                + "join role as rol on c.roleid = rol.id"
                + "join roster as ros on c.id = ros.crewid"
                + "join ship as s on s.id = ros.shipid";
            using(MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result.Add(new Roster
                    {
                        Name = (string)reader["fname"] + " " + (string)reader["lname"],
                        Age = (int)reader["age"],
                        Role = (string)reader["role"],
                        ShipName = (string)reader["name"],
                        RegNum = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return result;
        }

        public List<Roster> PilotRoster()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                OpenConnection();
            }
            List<Roster> result = new List<Roster>();
            string sql = "select c.fname, c.lname, c.age, rol.role, s.name, s.registration "
                + "from crew as c "
                + "join role as rol on c.roleid = rol.id"
                + "join roster as ros on c.id = ros.crewid"
                + "join ship as s on s.id = ros.shipid"
                + "where ros.pilotQualified = 1";
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    result.Add(new Roster
                    {
                        Name = (string)reader["fname"] + " " + (string)reader["lname"],
                        Age = (int)reader["age"],
                        Role = (string)reader["role"],
                        ShipName = (string)reader["name"],
                        RegNum = (string)reader["registration"]
                    });
                }
                reader.Close();
            }
            return result;

        }

    }  
}
            
            
            

