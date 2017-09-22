using Newtonsoft.Json;
using System;

namespace Jose
{
    [JsonObject]
    public class JoseHeader
    {
        [JsonProperty(PropertyName = "alg", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Algorithm { get; set; }

        [JsonProperty(PropertyName = "enc", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string ContentEncryption { get; set; }

        [JsonProperty(PropertyName = "zip", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string CompressionAlgorithm { get; set; }

        [JsonProperty(PropertyName = "jku", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public Uri JwkSetUri { get; set; }

        [JsonProperty(PropertyName = "jwk", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public JWK Jwk { get; set; }

        // TODO: Complete defining these too
        // "kid"
        // "x5u"
        // "x5c"
        // "x5t"
        // "x5t#S256"
        // "typ"
        // "cty"
        // "crit"
    }
}
