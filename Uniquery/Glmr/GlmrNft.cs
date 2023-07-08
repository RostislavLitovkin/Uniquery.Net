using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Uniquery
{
    public class GlmrNft
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool? Burned { get; set; }

        [JsonPropertyName("collection")]
        public GlmrCollection? Collection { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonPropertyName("currentOwner")]
        public string? CurrentOwner { get; set; }

        [JsonPropertyName("events")]
        public List<GlmrEvent>? Events { get; set; }

        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("meta")]
        public RmrkMetadata? Meta { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("price")]
        public BigInteger? Price { get; set; }

        [JsonPropertyName("royalty")]
        public int? Royalty { get; set; }

        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        [JsonPropertyName("count")]
        public BigInteger? Count { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }

        public override string ToString()
        {
            return "Glmr nft: " + Name + " - " + Sn + " owned by " + CurrentOwner + " (id: " + Id + ")"
                + "\n" + (Meta != null ? "Description : " + Meta.Description : "Metadata: " + Metadata) + "\n" +
                "Currently selling for: " + Price + "\n";
        }
    }
}
