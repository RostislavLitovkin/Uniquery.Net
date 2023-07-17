using System;
using System.Text.Json.Serialization;
using System.Numerics;

namespace Uniquery
{
    public class OnFinalityCollection : Collection
    {
        [JsonPropertyName("network")]
        public OnFinalityNetwork Network { get; set; }

        [JsonPropertyName("contract_address")]
        public string ContractAddress { get; set; }

        [JsonPropertyName("created_block")]
        public BigInteger CreatedBlock { get; set; }

        [JsonPropertyName("created_timestamp")]
        public BigInteger CreatedTimestamp { get; set; }

        private string creatorAddress;
        [JsonPropertyName("creator_address")]
        public string CreatorAddress { get => creatorAddress; set { creatorAddress = value; CurrentOwner = value; } }

        [JsonPropertyName("total_supply")]
        public BigInteger TotalSupply { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("contract_type")]
        public OnFinalityContractType ContractType { get; set; }
    }

}

