using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Location
    {
        public string location_id { get; private set; }
        public string location_name { get; private set; }
        public string location_description { get; private set; }

        public Location(string location_id, string location_name, string location_description)
        {
            this.location_id = location_id;
            this.location_name = location_name;
            this.location_description = location_description;
        }
    }
}
