using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkV2Collection : Collection
    {
        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("events")]
        public List<RmrkV2CollectionEvent> Events { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("media")]
        public string? Media { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("supply")]
        public int Supply { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}