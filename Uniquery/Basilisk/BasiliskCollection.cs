using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class BasiliskCollection
	{
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("distribution")]
        public int? Distribution { get; set; }

        [JsonPropertyName("events")]
        public List<BasiliskCollectionEvent> Events { get; set; } = new List<BasiliskCollectionEvent>();

        [JsonPropertyName("floor")]
        public BigInteger? Floor { get; set; }

        [JsonPropertyName("highestSale")]
        public BigInteger? HighestSale { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("meta")]
        public RmrkMetadata Meta { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("media")]
        public string Media { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nfts")]
        public List<NFTEntity> Nfts { get; set; } = new List<NFTEntity>();

        [JsonPropertyName("ownerCount")]
        public int OwnerCount { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("nftCount")]
        public int NftCount { get; set; }

        [JsonPropertyName("type")]
        public BasiliskCollectionType Type { get; set; }
    }
}

