using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Uniquery
{
    public class GlmrNft : Nft
    {

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool? Burned { get; set; }

        [JsonPropertyName("events")]
        public List<GlmrEvent>? Events { get; set; }

        [JsonPropertyName("hash")]
        public string? Hash { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

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
    }
}
