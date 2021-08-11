﻿using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H5ServersideSHS.Code
{
    public class CryptExample3
    {
        public string Encrypt(string payload, IDataProtector _protector)
        {
            return _protector.Protect(payload);
        }

        public string Decrypt(string protectetPayload, IDataProtector _protector)
        {
            return _protector.Unprotect(protectetPayload);
        }
    }
}
