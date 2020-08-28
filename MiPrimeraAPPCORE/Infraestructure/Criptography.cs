using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraAPPCORE.Infraestructure
{
    public class Criptography
    {
        public static bool ValidacionPassword(string Password, byte[] HashPassword, byte[] SaltPassword)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(SaltPassword))
            {
                var Computed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
                for (int i = 0; i < Computed.Length; i++)
                {
                    if (Computed[i] != HashPassword[i])
                    {
                        return false;
                    }

                }
            }
            return true;
        }

        public static void CrearPasswordEnCriptado(string Password, out byte[] HashPassword, out byte[] SaltPassword)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                SaltPassword = hmac.Key;
                HashPassword = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Password));
            }

        }
    }
}
