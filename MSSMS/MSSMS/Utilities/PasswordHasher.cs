using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSSMS.Utilities
{
    public class PasswordHasher
    {
        public byte[] CreateSalt()
        {
            var buffer = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buffer);
            }
            return buffer;
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            Argon2id argon2;

            using (argon2 = new Argon2id(Encoding.UTF8.GetBytes(password)))
            {
                argon2.Salt = salt;
                argon2.DegreeOfParallelism = 4; // four cores
                argon2.Iterations = 2;
                argon2.MemorySize = 1024 * 1024; // 1 GB
                
            }
            return argon2.GetBytes(16);
        }

        public bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }


    }
}
