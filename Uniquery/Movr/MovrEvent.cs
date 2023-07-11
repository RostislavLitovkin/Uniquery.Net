using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Uniquery
{
    public class MovrEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public long? BlockNumber { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("currentOwner")]
        public string CurrentOwner { get; set; }

        [JsonPropertyName("interaction")]
        public MovrInteraction Interaction { get; set; }

        [JsonPropertyName("meta")]
        public string Meta { get; set; }

        [JsonPropertyName("nft")]
        public MovrNft Nft { get; set; }

        public override string ToString()
        {
            return "Rmrk event: " + Interaction + " - " + Id + "\n";
        }
    }
}
