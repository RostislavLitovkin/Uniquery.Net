﻿using System;
using Microsoft.VisualBasic;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class BasiliskEvent
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
        public BasiliskInteraction Interaction { get; set; }

        [JsonPropertyName("meta")]
        public string Meta { get; set; }

        [JsonPropertyName("nft")]
        public BasiliskNft Nft { get; set; }

        public override string ToString()
        {
            return "Basilisk event: " + Interaction + " - " + Id + "\n";
        }
    }

}

