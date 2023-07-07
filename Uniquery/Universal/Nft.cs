using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class Nft
	{
        [JsonPropertyName("networkFormat")]
        public string NetworkFormat { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("collection")]
        public Collection Collection { get; set; } = new Collection();

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("currentOwner")]
        public string? CurrentOwner { get; set; }

        [JsonPropertyName("meta")]
        public RmrkMetadata? Meta { get; set; } = new RmrkMetadata();

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return NetworkFormat + " nft: " + Name + " owned by " + CurrentOwner + " (id: " + Id + ")"
                + "\nDescription : " + Meta.Description + "\n";
        }
    }
}

