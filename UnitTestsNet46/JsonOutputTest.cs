using Jose;
using Jose.jwe;
using System;
using Xunit;

namespace UnitTests
{
    public class JsonOutputTest : IDisposable
    {
        public JsonOutputTest()
        {
            Jose.JWT.DefaultSettings.JoseOutputSerialization = JoseSerialization.JSON;
        }

        public void Dispose()
        {
            Jose.JWT.DefaultSettings.JoseOutputSerialization = JoseSerialization.Compact;
        }

        [Fact]
        public void JsonOutput()
        {
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

            JweDto expectedOutput = new JweDto()
            {
                @protected = "eyJhbGciOiJkaXIiLCJlbmMiOiJBMjU2R0NNIn0",
                header = new JweHeader()
                {
                    alg = "dir",
                    enc = "A256GCM"
                },
                aad = "ZXlKaGJHY2lPaUprYVhJaUxDSmxibU1pT2lKQk1qVTJSME5OSW4w"
            };

            var mapper = new JSSerializerMapper();
            var parsedJwe = mapper.Parse<JweDto>(jwe);

            // test
            Assert.Equal(expectedOutput.@protected, parsedJwe.@protected);
            Assert.Equal(expectedOutput.header.alg, parsedJwe.header.alg);
            Assert.Equal(expectedOutput.header.enc, parsedJwe.header.enc);
            Assert.Equal(expectedOutput.aad, parsedJwe.aad);
        }
    }
}