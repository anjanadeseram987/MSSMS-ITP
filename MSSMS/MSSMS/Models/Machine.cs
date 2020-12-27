using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Machine
    {
        public string machineId { get; private set; }
        public string locationId { get; private set; }
        public string serialNumber { get; private set; }
        public string name { get; private set; }
        public string workingState { get; private set; }
        public string addedBy { get; private set; }
        public DateTime addedDate { get; private set; }
        public string description { get; private set; }
        public Location location { get; set; }
        public string loc_name { get; set; }
        public int critical_machine_issues { get; set; }
        public int total_machine_issues { get; set; }
        public int resolved_machine_issues { get; set; }
        

        public Machine()
        {

        }

        public Machine(string locationId, string serialNumber, string name, string workingState, string addedBy, DateTime addedDate, string description)
        {
            this.locationId = locationId;
            this.serialNumber = serialNumber;
            this.name = name;
            this.workingState = workingState;
            this.addedBy = addedBy;
            this.addedDate = addedDate;
            this.description = description;
        }

        public Machine(string machineId, string serialNumber, string name, string locationId, string workingState, string addedBy, DateTime addedDate, string description)
        {
            this.machineId = machineId;
            this.serialNumber = serialNumber;
            this.name = name;
            this.locationId = locationId;
            this.workingState = workingState;
            this.addedBy = addedBy;
            this.addedDate = addedDate;
            this.description = description;
        }

        public Machine(string machineId, string serialNumber, string name, string locationId, string workingState, string description)
        {
            this.machineId = machineId;
            this.serialNumber = serialNumber;
            this.name = name;
            this.locationId = locationId;
            this.workingState = workingState;
            this.description = description;
        }

        public Machine(string machineId, string serialNumber, string name, string locationId, string workingState, string addedBy, string description)
        {
            this.machineId = machineId;
            this.serialNumber = serialNumber;
            this.name = name;
            this.locationId = locationId;
            this.workingState = workingState;
            this.addedBy = addedBy;
            this.description = description;
        }
    }
}
