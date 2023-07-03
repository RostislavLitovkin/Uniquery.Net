using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkCollectionEvent
    {
        [JsonPropertyName("blockNumber")]
        public string? BlockNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("interaction")]
        public string Interaction { get; set; }

        [JsonPropertyName("meta")]
        public string Meta { get; set; }
    }
}

