using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkV2Emote
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nft")]
        public RmrkV2Nft Nft { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }
    }
}