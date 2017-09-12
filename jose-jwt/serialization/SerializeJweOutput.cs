using System;
using System.Collections.Generic;
using System.Text;

namespace Jose
{
    public class SerializeOutput
    {
        /// <summary>
        /// This will serialize all the necessary components of a JWE into one of the many 
        /// standards per RFC 7516. It may be preferred to define concrete classes + attributes 
        /// rather than assemble the output object via code as a Dictionary but unclear about 
        /// hard dependency on newtonsoft. Defer to @dvsekhvalnov
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="encryptedCek"></param>
        /// <param name="protectedHeaderBase64">BASE64URL(UTF8(JWE Protected Header))</param>
        /// <param name="unprotectedHeader">Additional header fields that are not integrity 
        /// protected</param>
        /// <param name="header"></param>
        /// <param name="aad"></param>
        /// <param name="iv"></param>
        /// <param name="ciphertext"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string AsJwe(JwtSettings settings, 
            byte[] encryptedCek,
            string protectedHeaderBase64,
            IDictionary<string, object> unprotectedHeader,
            IDictionary<string, object> header,
            byte[] aad, 
            byte[] iv, 
            byte[] ciphertext, 
            byte[] tag)
        {
            switch (settings.JoseOutputSerialization)
            {
                case JoseSerialization.JSON:
                    // per https://tools.ietf.org/html/rfc7516#section-7.2
                    var jweOutJsonFlat = new Dictionary<string, object>();
                    
                    // with the value BASE64URL(UTF8(JWE Protected Header))
                    if (!string.IsNullOrEmpty(protectedHeaderBase64))
                        jweOutJsonFlat.Add("protected", protectedHeaderBase64);

                    // with the value JWE Shared Unprotected Header
                    if (unprotectedHeader != null && unprotectedHeader.Count > 1)
                        jweOutJsonFlat.Add("unprotected", unprotectedHeader);

                    // TODO: the library's API needs to support multi-recipient, for now just single
                    jweOutJsonFlat.Add("header", header); // with the value JWE Per - Recipient Unprotected Header

                    // with the value BASE64URL(JWE Encrypted Key) IFF exists
                    if (encryptedCek != null && encryptedCek != Arrays.Empty)
                        jweOutJsonFlat.Add("encrypted_key", Base64Url.Encode(encryptedCek));

                    jweOutJsonFlat.Add("aad", Base64Url.Encode(aad));               // with the value BASE64URL(JWE AAD)
                    jweOutJsonFlat.Add("iv", Base64Url.Encode(iv));                 // with the value BASE64URL(JWE Initialization Vector)
                    jweOutJsonFlat.Add("ciphertext", Base64Url.Encode(ciphertext)); // with the value BASE64URL(JWE Ciphertext)
                    jweOutJsonFlat.Add("tag", Base64Url.Encode(tag));               // with the value BASE64URL(JWE Authentication Tag)
                    return settings.JsonMapper.Serialize(jweOutJsonFlat);
                default:
                    return Compact.Serialize(Encoding.UTF8.GetBytes(settings.JsonMapper.Serialize(header)), encryptedCek, iv, ciphertext, tag);
            }
        }

        public static string AsJws()
        {
            throw new NotImplementedException();
        }
    }
}
