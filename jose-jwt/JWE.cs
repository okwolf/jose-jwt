using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose
{    
    public class JWE
    {
        public static string Encrypt<T>(T payload, JWK[] recipients, JweEncryption enc, JweCompression? compression = null, IDictionary<string, object> extraHeaders = null, JwtSettings settings = null)
        {
            return "";
        }

        public static T Decrypt<T>(string JweJson, JWK[] recipients, JweEncryption enc, JwtSettings settings = null)
        {
            return default(T);
        }

    }
}
