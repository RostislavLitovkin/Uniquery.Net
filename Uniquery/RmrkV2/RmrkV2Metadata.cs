using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkV2Metadata
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("image")]
        public string? Image { get; set; }

        [JsonPropertyName("attributes")]
        public List<RmrkV2Attribute>? Attributes { get; set; }

        [JsonPropertyName("animationUrl")]
        public string? AnimationUrl { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}