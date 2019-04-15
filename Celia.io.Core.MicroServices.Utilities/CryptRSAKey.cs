using System;
using System.Collections.Generic;
using System.Text;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class CryptRSAKey
    { 
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Exponent { get; set; }
        public string Modulus { get; set; }
    }
}
