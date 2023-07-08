using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public class GlmrEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("interaction")]
        public GlmrInteraction Interaction { get; set; }

        [JsonPropertyName("meta")]
        public string Meta { get; set; }

        [JsonPropertyName("nft")]
        public GlmrNft Nft { get; set; }

        public override string ToString()
        {
            return "Glmr event: " + Interaction + " - " + Id + "\n";
        }
    }
}
