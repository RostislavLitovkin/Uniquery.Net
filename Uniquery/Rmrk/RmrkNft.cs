using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkNft
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("instance")]
        public string? Instance { get; set; }

        [JsonPropertyName("transferable")]
        public int? Transferable { get; set; }

        [JsonPropertyName("collection")]
        public RmrkCollection Collection { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        // SN = Serial number
        [JsonPropertyName("sn")]
        public string? SN { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("currentOwner")]
        public string? CurrentOwner { get; set; }

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

        [JsonPropertyName("meta")]
        public RmrkMetadata? Meta { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("emoteCount")]
        public int EmoteCount { get; set; }

        public override string ToString()
        {
            return "Rmrk nft: " + Name + " - " + SN + " owned by " + CurrentOwner + " (id: " + Id + ")"
                + "\n" + (Meta != null ? "Description : " + Meta.Description : "Metadata: " + Metadata) + "\n" +
                "Currently selling for: " + Price + "\n";
        }
    }
}

