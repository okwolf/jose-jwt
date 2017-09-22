using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose.JsonWebKey
{
    /// <summary>
    /// JsonWebKey algorithms per https://tools.ietf.org/html/rfc7518
    /// </summary>
    public static class EncryptionAlgorithm
    {
        /*
        +--------------+-------------------------------+--------------------+
        | "alg" Param  | Digital Signature or MAC      | Implementation     |
        | Value        | Algorithm                     | Requirements       |
        +--------------+-------------------------------+--------------------+
        | HS256        | HMAC using SHA-256            | Required           |
        | HS384        | HMAC using SHA-384            | Optional           |
        | HS512        | HMAC using SHA-512            | Optional           |
        | RS256        | RSASSA-PKCS1-v1_5 using       | Recommended        |
        |              | SHA-256                       |                    |
        | RS384        | RSASSA-PKCS1-v1_5 using       | Optional           |
        |              | SHA-384                       |                    |
        | RS512        | RSASSA-PKCS1-v1_5 using       | Optional           |
        |              | SHA-512                       |                    |
        | ES256        | ECDSA using P-256 and SHA-256 | Recommended+       |
        | ES384        | ECDSA using P-384 and SHA-384 | Optional           |
        | ES512        | ECDSA using P-521 and SHA-512 | Optional           |
        | PS256        | RSASSA-PSS using SHA-256 and  | Optional           |
        |              | MGF1 with SHA-256             |                    |
        | PS384        | RSASSA-PSS using SHA-384 and  | Optional           |
        |              | MGF1 with SHA-384             |                    |
        | PS512        | RSASSA-PSS using SHA-512 and  | Optional           |
        |              | MGF1 with SHA-512             |                    |
        | none         | No digital signature or MAC   | Optional           |
        |              | performed                     |                    |
        +--------------+-------------------------------+--------------------+
        */

        public const string HS256 = "HS256";
        public const string HS384 = "HS384";
        public const string HS512 = "HS512";
        public const string RS256 = "RS256";
        public const string RS384 = "RS384";
        public const string RS512 = "RS512";
        public const string ES256 = "ES256";
        public const string ES384 = "ES384";
        public const string ES512 = "ES512";
        public const string PS256 = "PS256";
        public const string PS384 = "PS384";
        public const string PS512 = "PS512";
        public const string none = "none";



        public const string RSAOAEP = "RSA-OAEP";
        public const string RSA15 = "RSA1_5";

        // RSAES OAEP using SHA-256 and MGF1 with SHA-256 
        // defined https://tools.ietf.org/html/draft-ietf-jose-json-web-algorithms        
        public const string RSAOAEP256 = "RSA-OAEP-256";

        public static string[] AllAlgorithms
        {
            get { return new[] { RSA15, RSAOAEP, RSAOAEP256 }; }
        }
    }
}
