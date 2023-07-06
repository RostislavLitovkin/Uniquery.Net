using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkNft : Nft
    {
        [JsonPropertyName("instance")]
        public string? Instance { get; set; }

        [JsonPropertyName("transferable")]
        public int? Transferable { get; set; }

        private RmrkCollection collection;
        [JsonPropertyName("collection")]
        public RmrkCollection Collection { get => collection; set { base.Collection = value; collection = value; } }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        // SN = Serial number
        [JsonPropertyName("sn")]
        public string? SN { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("price")]
        public BigInteger Price { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("emotes")]
        public List<RmrkEmote>? Emotes { get; set; }

        [JsonPropertyName("events")]
        public List<RmrkCollectionEvent>? Events { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("emoteCount")]
        public int EmoteCount { get; set; }
    }
}

