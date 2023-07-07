using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class BasiliskCollection : Collection
    {
        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("distribution")]
        public int? Distribution { get; set; }

        [JsonPropertyName("events")]
        public List<BasiliskCollectionEvent> Events { get; set; } = new List<BasiliskCollectionEvent>();

        [JsonPropertyName("floor")]
        public BigInteger? Floor { get; set; }

        [JsonPropertyName("highestSale")]
        public BigInteger? HighestSale { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("media")]
        public string Media { get; set; }

        [JsonPropertyName("ownerCount")]
        public int OwnerCount { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("type")]
        public BasiliskCollectionType Type { get; set; }
    }
}

