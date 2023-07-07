using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkV2Nft : Nft
    {
        [JsonPropertyName("blockNumber")]
        public long BlockNumber { get; set; }

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("emoteCount")]
        public int EmoteCount { get; set; }

        [JsonPropertyName("emotes")]
        public List<RmrkV2Emote>? Emotes { get; set; }

        [JsonPropertyName("events")]
        public List<RmrkV2CollectionEvent>? Events { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("instance")]
        public string? Instance { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("media")]
        public string? Media { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("pending")]
        public bool Pending { get; set; }

        [JsonPropertyName("price")]
        public long Price { get; set; }

        [JsonPropertyName("royalty")]
        public float? Royalty { get; set; }

        [JsonPropertyName("recipient")]
        public string? Recipient { get; set; }

        [JsonPropertyName("sn")]
        public string? Sn { get; set; }

        [JsonPropertyName("transferable")]
        public int? Transferable { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public string? Version { get; set; }
    }
}