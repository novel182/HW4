// Novel Poudel
// Worked With : Sabin Sapkota & Bishesh Tuladhar

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace linqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // We will need implictly typed variables for the return values
            // We need to know the type ahead of time!
            // The compiler cannot, however
            // var myLinqInt = 0;

            CrewMember mal = new CrewMember(
                    "Malcolm",
                    "Reynolds",
                    "Captain",
                    "45"
                );

            CrewMember zoe = new CrewMember(
                    "Zoe",
                    "Washburne",
                    "First Mate",
                    "34"
                );

            CrewMember jayne = new CrewMember(
                    "Jayne",
                    "Cobb",
                    "Public Relations",
                    "50"
                );

            CrewMember wash = new CrewMember(
                    "Hoban",
                    "Washburne",
                    "Pilot",
                    "43"
                );

            CrewMember inara = new CrewMember(
                    "Inara",
                    "Serra",
                    "Ambassador",
                    "39"
                );

            CrewMember book = new CrewMember(
                    "Derrial",
                    "Book",
                    "Shepherd",
                    "36"
                );

            CrewMember kaylee = new CrewMember(
                    "Kaywinnit",
                    "Frye",
                    "Engineer",
                    "37"
                );

            CrewMember simon = new CrewMember(
                    "Simon",
                    "Tam",
                    "Doctor",
                    "38"
                );

            CrewMember river = new CrewMember(
                    "River",
                    "Tam",
                    "Psyker",
                    "41"
                );

            List<CrewMember> roster = new List<CrewMember> {
                mal, zoe, jayne, wash, inara, book, kaylee, simon, river
            };

            XmlRoster xmlRoster = new XmlRoster(roster);

            CrewMember yoSaffBridge = new CrewMember(
                "Yolanda Saffron Bridget",
                "Unknown",
                "Hazard",
                "43"
                );

            xmlRoster.AddCrew(yoSaffBridge);
            xmlRoster.Print();

            XElement serenity = xmlRoster.GetXmlRoster();
            //Console.WriteLine(serenity);

            // Query to find Tam 
            IEnumerable<XElement> tams = from crew in serenity.Descendants("crewMember")
                                         where (string)crew.Attribute("Lname") == "Tam"
                                         select crew;
            Console.WriteLine("Found {0} Tams. Two by two, hands of blue...", tams.Count());
            Console.WriteLine();
            foreach (XElement tam in tams) {
                Console.WriteLine(tam);
            }
            Console.WriteLine();

            //Query to find Washburne and finding type  
            var washburnes = from crew in serenity.Descendants("crewMember")
                                         where (string)crew.Attribute("Lname") == "Washburne"
                                               select crew;
            Console.WriteLine("Found {0} Washburne. Two by two, hands of blue...", washburnes.Count());
            Console.WriteLine();
            foreach (var washburne in washburnes)
            {
                Console.WriteLine(washburne);
                Console.WriteLine("Type : {0}", washburne.GetType());
            }

            //Query to find all the crew whose last name starting from A to M
            var AtoM = from crew in serenity.Descendants("crewMember")
                       where ((string)crew.Attribute("Lname"))[0] >= 65 && ((string)crew.Attribute("Lname"))[0] <= 78
                       orderby (string)crew.Attribute("Lname") descending
                       select crew;
            Console.WriteLine("Found {0} Crew whose Last Name starting between letter A to M. Two by two, hands of blue...", AtoM.Count());
            Console.WriteLine();
            foreach (var atom in AtoM)
            {
                Console.WriteLine(atom);
            }
            Console.WriteLine();

            //Query to calculate the average age of the crew
            var AvgAge = from crew in serenity.Descendants("crewMember")
                         select ((string)crew.Attribute("Age"));
            double avg = 0;
            foreach (var A in AvgAge)
            {
                avg += Convert.ToDouble(A);
            }
            Console.WriteLine("The average age of the crew members : {0}",(avg/AvgAge.Count()));
            Console.WriteLine();

            //Query to find Ship Operator
            var HighPos = from crew in serenity.Descendants("crewMember")
                             where (string)crew.Attribute("Position") == "Captain"  || 
                             (string)crew.Attribute("Position") == "First Mate" || 
                             (string)crew.Attribute("Position") == "Pilot"
                              select crew;
            Console.WriteLine("Found {0} Ship Operator. Two by two, hands of blue...", HighPos.Count());
            Console.WriteLine();
            foreach (var hp in HighPos)
            {
                Console.WriteLine(hp);
            }
            Console.WriteLine();

            //Query to find Non-Ship Operator
            var LowPos = from crew in serenity.Descendants("crewMember")
                          where (string)crew.Attribute("Position") != "Captain" &&
                          (string)crew.Attribute("Position") != "First Mate" &&
                          (string)crew.Attribute("Position") != "Pilot"
                          select crew;
            Console.WriteLine("Found {0} Non-Ship Operator. Two by two, hands of blue...", LowPos.Count());
            Console.WriteLine();
            foreach (var lp in LowPos)
            {
                Console.WriteLine(lp);
            }

        }
    }
}
