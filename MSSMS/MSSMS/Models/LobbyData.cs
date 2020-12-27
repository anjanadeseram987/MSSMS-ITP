using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class LobbyData
    {
        public int userAccountCount { get; set; }
        public int employeeCount { get; set; }
        public int unauthorizedUACount { get; set; }
        public int deptCount { get; set; }
        public int desigCount { get; set; }
        public int machineCount { get; set; }
        public int issueCount { get; set; }
        public int issueFixesCount { get; set; }
        public int ordersInProgressCount { get; set; }
        public int completedOrdersCount { get; set; }
        public int completedMCDuringMonthCount { get; set; }
        public int pendingProductionPlansNA { get; set; }
        public int pendingShippingSchedulesNA { get; set; }
        public int completedOrdersDuringMonthCount { get; set; }
        public int receivedOrdersDuringMonth { get; set; }
        public int pendingSchedulesCount { get; set; }
        public int approvedSchedulesCount { get; set; }
        public int expiredMCDuringMonthCount { get; set; }
        public int storedMCDuringMonthCount { get; set; }
        public int nearlyExpiredMCDuringMonthCount { get; set; }

        public LobbyData()
        {

        }
    }
}
