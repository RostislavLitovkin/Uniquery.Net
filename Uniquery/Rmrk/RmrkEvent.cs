using System;
using Microsoft.VisualBasic;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class RmrkEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger? BlockNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("interaction")]
        public RmrkInteraction Interaction { get; set; }

        [JsonPropertyName("meta")]
        public string Meta { get; set; }

        [JsonPropertyName("nft")]
        public RmrkNft Nft { get; set; }
    }

}

