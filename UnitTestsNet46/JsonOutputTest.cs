using Jose;
using System;
using Xunit;

namespace UnitTests
{
    public class JsonOutputTest
    {
        [Fact]
        public void JsonOutput()
        {
            Jose.JWT.DefaultSettings.JoseOutputSerialization = JoseSerialization.JSON;
            var payload = new
            {
                Email = "username@example.com",
                SSN = 1234567890,
                Address = new
                {
                    Address1 = "123 Main St",
                    Address2 = "",
                    City = "San Diego",
                    State = "California",
                    Country = "USA"
                }
            };

            var secretKey = ByteUtils.StringToByteArray("feffe9928665731c6d6a8f9467308308feffe9928665731c6d6a8f9467308308");

            // work
            var jwe = Jose.JWT.Encode(payload, secretKey, JweAlgorithm.DIR, JweEncryption.A256GCM);
            Console.WriteLine($"JWE is: {jwe}");

            // test
            Assert.True(jwe != null);            
        }
    }
}