using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose.JsonWebKey
{
    /// <summary>
    /// Per https://tools.ietf.org/html/rfc7517#section-4.3
    /// </summary>
    public static class Operation
    {
        public const string Sign = "sign";
        public const string Verify = "verify";
        public const string Encrypt = "encrypt";
        public const string Decrypt = "decrypt";
        public const string Wrap = "wrapKey";
        public const string Unwrap = "unwrapKey";
        public const string DeriveKey = "deriveKey";
        public const string DeriveBits = "deriveBits";
        //TODO: Should we add masking, format preserving encryption etc?

        public static string[] AllOperations
        {
            get { return new string[] { Sign, Verify, Encrypt, Decrypt, Wrap, Unwrap, DeriveKey, DeriveBits }; }
        }
    }
}
