using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class Collection
	{
        [JsonPropertyName("networkFormat")]
        public string NetworkFormat { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("meta")]
        public RmrkMetadata Meta { get; set; } = new RmrkMetadata();

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nfts")]
        public List<Nft> Nfts { get; set; } = new List<Nft>();

        [JsonPropertyName("nftCount")]
        public int? NftCount { get; set; }

        public override string ToString()
        {
            return NetworkFormat + " collection: " + Name + " by " + CurrentOwner + " (id: " + Id + ")"
                + "\nDescription : " + Meta.Description + "\n";
        }
    }
}

