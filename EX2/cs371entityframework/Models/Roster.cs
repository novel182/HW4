using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs371entityframework.Models
{
    //when I didn't include 'public' keyword in this class,
    //the FullRoster function in MySqlDb gave a syntax error "List<Roster> is less accessible than MySqlDb.FullRoster()"
    public class Roster
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string ShipName { get; set; }
        public string RegNum { get; set; }
    }
}
