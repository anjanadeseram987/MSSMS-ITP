using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Models
{
    public class ResetToken
    {
        public string userEmail { get; private set; }
        public string token { get; private set; }
        public int isTokenUsed { get; private set; }
        public DateTime tokenExpiration { get; private set; }

        public ResetToken(string userEmail, string token, DateTime tokenExpiration,int isTokenUsed)
        {
            this.userEmail = userEmail;
            this.token = token;
            this.tokenExpiration = tokenExpiration;
            this.isTokenUsed = isTokenUsed;
        }
    }
}
