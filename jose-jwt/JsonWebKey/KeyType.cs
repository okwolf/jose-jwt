using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose.JsonWebKey
{
    /// <summary>
    /// JSON Web Key type per https://tools.ietf.org/html/rfc7518#section-6.1
    /// </summary>
    public class KeyType
    {
        public const string EllipticCurve = "EC";
        public const string Rsa = "RSA";
        public const string Octet = "oct";

        public static string[] AllTypes
        {
            get { return new[] { EllipticCurve, Rsa, Octet }; }
        }        
    }
}
