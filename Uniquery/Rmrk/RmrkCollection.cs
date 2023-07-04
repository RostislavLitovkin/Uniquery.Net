using System;
using System.Numerics;

namespace Uniquery
{
    public class RmrkCollection
    {
        public string? Version { get; set; }
        public string? Name { get; set; }
        public int Max { get; set; }
        public string? Issuer { get; set; }
        public string? Symbol { get; set; }
        public string Id { get; set; }
        public string? Metadata { get; set; }
        public string? CurrentOwner { get; set; }
        public List<RmrkCollectionEvent>? Events { get; set; }
        public BigInteger? BlockNumber { get; set; }
        public RmrkMetadata? Meta { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int NftCount { get; set; }
        public int Supply { get; set; }

        public override string ToString()
        {
            return "Rmrk collection: " + Name + " by " + Issuer + " (id: " + Id + ")"
                + "\n" + (Meta != null ? "Description : " + Meta.Description : "Metadata: " + Metadata) + "\n";
        }
    }
}

