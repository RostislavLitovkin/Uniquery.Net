using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Numerics;

namespace Uniquery
{
    public class GlmrCollection : Collection
    {
        public BigInteger? BlockNumber { get; set; }
        public bool? Burned { get; set; }
        public int Max { get; set; }
        public String Issuer { get; set; }
        public String? Metadata { get; set; }
        public String? Symbol { get; set; }
        public String Type { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
