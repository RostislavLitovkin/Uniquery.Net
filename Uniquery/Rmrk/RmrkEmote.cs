using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkEmote
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("nft")]
        public RmrkNft Nft { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

}

