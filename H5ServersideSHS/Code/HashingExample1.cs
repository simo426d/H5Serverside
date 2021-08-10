using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace H5ServersideSHS.Code
{
    public class HashingExample1
    {
        public string GetHashedText_MD5(string valueToHash)
        {
            byte[] valueAsBytes = ASCIIEncoding.ASCII.GetBytes(valueToHash);

            byte[] valueT = MD5.HashData(valueAsBytes);

            string hashedValueAsString = Convert.ToBase64String(valueT);

            return hashedValueAsString;
        }

    }
}
