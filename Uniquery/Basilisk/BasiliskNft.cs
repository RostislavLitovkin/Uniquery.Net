using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class BasiliskNft : Nft
    {
        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        private BasiliskCollection collection;
        [JsonPropertyName("collection")]
        public BasiliskCollection Collection { get => collection; set { collection = value; base.Collection = value; } }

        [JsonPropertyName("events")]
        public List<BasiliskEvent> Events { get; set; }

        [JsonPropertyName("offers")]
        public List<BasiliskOffer> Offers { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("media")]
        public string Media { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("price")]
        public BigInteger? Price { get; set; }

        [JsonPropertyName("royalty")]
        public float? Royalty { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }

        [JsonPropertyName("sn")]
        public string Sn { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}

