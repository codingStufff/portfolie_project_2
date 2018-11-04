using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace rawdata_pp_2.Service
{
    public class PasswordService
    {
        public RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();
        public string GenerateSalt(int size)
        {
            var buffer = new byte[size];
            _rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public string HashPassword(string password, string salt, int size)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Encoding.UTF8.GetBytes(salt),
                KeyDerivationPrf.HMACSHA256,
                1000,
                size));
        }
        
    }
}
