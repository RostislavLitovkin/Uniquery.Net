using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class BasiliskNft
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("collection")]
        public BasiliskCollection Collection { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("events")]
        public List<BasiliskEvent> Events { get; set; }

        [JsonPropertyName("offers")]
        public List<BasiliskEvent> Events { get; set; }
        // Events and offers are list of Event and Offer respectively. Definitions for Event and Offer are not provided here.
        // Assuming they are already defined elsewhere in your code.

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("meta")]
        public RmrkMetadata Meta { get; set; }

        [JsonPropertyName("media")]
        public string Media { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

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

