using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jose.jwe
{
    public class JweHeader
    {

        public string alg { get; set; }
        public string enc { get; set; }
    }

    public class JweDto
    {
        public string @protected { get; set; }
        public JweHeader header { get; set; }
        public string aad { get; set; }
        public string iv { get; set; }
        public string ciphertext { get; set; }
        public string tag { get; set; }
    }

}
