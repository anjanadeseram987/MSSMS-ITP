using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class Buyer
    {
        public string buyerId { get; private set; }
        public string buyerName { get; private set; }
        public int buyerUsage { get; set; } = -1;
        public string buyerEmail { get; private set; }
        public string buyerDescription { get; private set; }

        public Buyer(string buyerId, string buyerName)
        {
            this.buyerId = buyerId;
            this.buyerName = buyerName;
        }

        public Buyer(string buyerId, string buyerName, string buyerEmail, string buyerDescription) : this(buyerId, buyerName)
        {
            this.buyerEmail = buyerEmail;
            this.buyerDescription = buyerDescription;
        }
    }
}
