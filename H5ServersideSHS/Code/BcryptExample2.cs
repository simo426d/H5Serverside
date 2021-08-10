using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using BCrypt.Net;

namespace H5ServersideSHS.Code
{
    public class BcryptExample2
    {
        public string GetEncryptetText(string valueToEncrypt)
        {
            string encryptetText = BCrypt.Net.BCrypt.HashPassword(valueToEncrypt);

            return encryptetText;
        }

        public string GetDecryptetText(string valueToDecrypt, string correctHash)
        {
            string verified = "";

            var decryptetText = BCrypt.Net.BCrypt.Verify(valueToDecrypt, correctHash);

            if(decryptetText == true)
            {
                verified = "sandt";
                return verified;
            }
            else
            {
                verified = "falsk";
                return verified;
            }

        }
    }
}
