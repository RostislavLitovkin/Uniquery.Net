using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkV2Collection
    {
        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("currentOwner")]
        public string? CurrentOwner { get; set; }

        [JsonPropertyName("events")]
        public List<RmrkV2CollectionEvent> Events { get; set; }

        [JsonPropertyName("hash")]
        public string Hash { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("issuer")]
        public string? Issuer { get; set; }

        [JsonPropertyName("max")]
        public int Max { get; set; }

        [JsonPropertyName("media")]
        public string? Media { get; set; }

        [JsonPropertyName("meta")]
        public RmrkV2Metadata? Meta { get; set; }

        [JsonPropertyName("metadata")]
        public string? Metadata { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nftCount")]
        public int NftCount { get; set; }

        // Nfts is represented as a list of NFTEntity objects with additional parameters
        // You would need to define NFTEntity, NFTEntityOrderByInput, NFTEntityWhereInput classes separately
        // [JsonPropertyName("nfts")]
        // public List<NFTEntity> Nfts { get; set; }

        [JsonPropertyName("supply")]
        public int Supply { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"BlockNumber: {BlockNumber}");
            stringBuilder.AppendLine($"CreatedAt: {CreatedAt}");
            stringBuilder.AppendLine($"CurrentOwner: {CurrentOwner}");

            if (Events != null && Events.Count > 0)
            {
                stringBuilder.AppendLine("Events:");
                foreach (var e in Events)
                {
                    stringBuilder.AppendLine($"\t{e}");
                }
            }

            stringBuilder.AppendLine($"Hash: {Hash}");
            stringBuilder.AppendLine($"Id: {Id}");
            stringBuilder.AppendLine($"Image: {Image}");
            stringBuilder.AppendLine($"Issuer: {Issuer}");
            stringBuilder.AppendLine($"Max: {Max}");
            stringBuilder.AppendLine($"Media: {Media}");
    
            if(Meta != null)
            {
                stringBuilder.AppendLine($"Meta: {Meta}");
            }

            stringBuilder.AppendLine($"Metadata: {Metadata}");
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"NftCount: {NftCount}");

            // Uncomment if Nfts are implemented
            // if(Nfts != null && Nfts.Count > 0)
            // {
            //     stringBuilder.AppendLine("Nfts:");
            //     foreach(var nft in Nfts)
            //     {
            //         stringBuilder.AppendLine($"\t{nft}");
            //     }
            // }

            stringBuilder.AppendLine($"Supply: {Supply}");
            stringBuilder.AppendLine($"Symbol: {Symbol}");
            stringBuilder.AppendLine($"UpdatedAt: {UpdatedAt}");
            stringBuilder.AppendLine($"Version: {Version}");

            return stringBuilder.ToString();
        }
    }
}