using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace linqTest
{
    class XmlRoster
    {
        List<CrewMember> roster;
        XmlDocument xmlRoster;
        bool rosterUpToDate;

        public XmlRoster() {
            roster = new List<CrewMember>();
        }

        public XmlRoster(List<CrewMember> roster) {
            this.roster = roster;
        }

        public XmlDocument GetXmlRoster() {
            if (!rosterUpToDate)
            {
                GenerateXmlRoster();
            } 
            return xmlRoster;
        }

        public void AddCrew(CrewMember newCrew) {
            rosterUpToDate = false;
            roster.Add(newCrew);
        }

        public void AddCrew(List<CrewMember> newRoster) {
            rosterUpToDate = false;
            roster.AddRange(newRoster);
        }

        public void RemoveCrew(CrewMember exCrew) {
            rosterUpToDate = false;
            roster.Remove(exCrew);
        }

        public void RemoveCrew(List<CrewMember> exCrew)
        {
            rosterUpToDate = false;
            foreach (CrewMember ex in exCrew) {
                roster.Remove(ex);
            }
        }

        public void GenerateXmlRoster() {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("crew");
            doc.AppendChild(rootNode);

            foreach (CrewMember crewMember in roster) {
                XmlNode crewMemberNode = doc.CreateElement("crewMember");
                XmlAttribute fname = doc.CreateAttribute("fname");
                fname.Value = crewMember.Fname;
                crewMemberNode.Attributes.Append(fname);
                XmlAttribute lname = doc.CreateAttribute("lname");
                lname.Value = crewMember.Lname;
                crewMemberNode.Attributes.Append(lname);
                XmlAttribute position = doc.CreateAttribute("position");
                position.Value = crewMember.Position;
                crewMemberNode.Attributes.Append(position);
                XmlAttribute rank = doc.CreateAttribute("rank");
                rank.Value = crewMember.Rank;
                crewMemberNode.Attributes.Append(rank);
                rootNode.AppendChild(crewMemberNode);
            }

            xmlRoster = doc;
            rosterUpToDate = true;
        }

        public void Print()
        {
            string sep = new string('=', 35);
            string title = "Current Crew";
            string filler = new string('=', title.Length);
            if (!rosterUpToDate)
            {
                GenerateXmlRoster();    
            }
            Console.WriteLine("{0}{1}{0}", sep, title);
            foreach (XmlNode child in xmlRoster.ChildNodes[0].ChildNodes) {
                Console.WriteLine(child.OuterXml);
            }
            Console.WriteLine("{0}{1}{0}", sep, filler);
        }

        public void Write(string filename) {
            xmlRoster.Save(filename);
        }
    }
}
