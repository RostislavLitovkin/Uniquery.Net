using System;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class BasiliskOffer
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("blockNumber")]
        public BigInteger BlockNumber { get; set; }

        [JsonPropertyName("caller")]
        public string Caller { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        // Assuming OfferEvent and OfferEventWhereInput are already defined
        // Add logic to handle the events as per the application's need

        [JsonPropertyName("expiration")]
        public BigInteger Expiration { get; set; }

        [JsonPropertyName("nft")]
        public BasiliskNft Nft { get; set; }

        [JsonPropertyName("price")]
        public BigInteger Price { get; set; }

        [JsonPropertyName("status")]
        public BasiliskOfferStatus Status { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }

}

