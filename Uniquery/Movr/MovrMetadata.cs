using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public class MovrMetadata
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("attributes")]
        public List<RmrkAttribute> Attributes { get; set; }

        [JsonPropertyName("animationUrl")]
        public string AnimationUrl { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
