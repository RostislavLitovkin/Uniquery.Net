using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Numerics;
using Uniquery.GlmrImpl;

namespace Uniquery
{
    public class GlmrCollections
    {
        public BigInteger? BlockNumber { get; set; }
        public bool? Burned { get; set; }
        public DateTime CreatedAt { get; set; }
        public String CurrentOwner { get; set; }
        public String Id { get; set; }
        public int Max { get; set; }
        public String Issuer { get; set; }
        public String? Metadata { get; set; }
        public RmrkMetadata? Meta { get; set; }
        public String? Name { get; set; }
        public List<GlmrNft> Nfts { get; set; }
        public String? Symbol { get; set; }
        public String Type { get; set; }
        public DateTime UpdatedAt { get; set; }

        public override string ToString()
        {
            return "Glmr collection: " + Name + " by " + Issuer + " (id: " + Id + ")"
                + "\n" + (Meta != null ? "Description : " + Meta.Description : "Metadata: " + Metadata) + "\n";
        }
    }
}
