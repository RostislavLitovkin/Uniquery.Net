using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkAttribute
    {
        [JsonPropertyName("display")]
        public string? Display { get; set; }

        [JsonPropertyName("trait")]
        public string? Trait { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}

