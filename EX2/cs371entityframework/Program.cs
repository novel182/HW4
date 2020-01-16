//Novel Poudel
//Worked with Sabin Sapkota and Bishesh Tuladhar and Pukar Mahat
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
    class Program
    {
        static void Main(string[] args)
        {
            //do
            //{
                //try
                //{
                    MySqlDb fleet = new MySqlDb("db4free.net", "cs371student", "whitworth", "cs371ado");
                    fleet.OpenConnection();
                    Console.Clear();
                    Console.WriteLine("CONNECTION ESTABLISHED");

                    List<Ship> ships = fleet.GetAllShips();
                    foreach (Ship s in ships)
                    {
                        Console.WriteLine("{0} has registration number {1}", s.Name, s.Registration);
                    }
                    Console.WriteLine("\n\nFull Roster\n");
                    List<Roster> fullRosters = fleet.FullRoster();
                    foreach (Roster r in fullRosters)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", r.Name, r.Age, r.Role, r.ShipName, r.RegNum);
                    }
                    Console.WriteLine("\n\nPilot Roster\n");
                    List<Roster> pilotRosters = fleet.PilotRoster();
                    foreach (Roster r in pilotRosters)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", r.Name, r.Age, r.Role, r.ShipName, r.RegNum);
                    }
                //    break;
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("Connection failed: {0}", e.Message);
                //}
            //} while (true);
        }
    }
}
