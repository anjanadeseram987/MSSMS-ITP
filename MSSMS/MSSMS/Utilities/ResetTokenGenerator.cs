using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Utilities
{
    class ResetTokenGenerator
    {
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public static string generateToken()
        {
            byte[] randomByte = new byte[4];
            rngCsp.GetBytes(randomByte);
            int token = BitConverter.ToInt32(randomByte, 0);
            return (Math.Abs(token%999999+0)).ToString("D6");          
        }

    }
}
