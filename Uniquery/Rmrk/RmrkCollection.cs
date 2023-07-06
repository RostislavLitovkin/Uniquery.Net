using System;
using System.Numerics;

namespace Uniquery
{
    public class RmrkCollection : Collection
    {
        public string? Version { get; set; }
        public int Max { get; set; }
        public string? Issuer { get; set; }
        public string? Symbol { get; set; }
        public string? Metadata { get; set; }
        public List<RmrkCollectionEvent>? Events { get; set; }
        public BigInteger? BlockNumber { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Supply { get; set; }
    }
}

