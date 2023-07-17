using System;
using System.Text.Json.Serialization;
using System.Numerics;
using Substrate.NetApi.Model.Meta;

namespace Uniquery
{
    public class OnFinalityNft : Nft
    {
        private OnFinalityCollection collection;
        [JsonPropertyName("id")]
        public OnFinalityCollection Collection { get => collection; set
            {
                collection = value;
                base.Collection = value;
            }
        }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        private string tokenId;
        [JsonPropertyName("tokenId")]
        public string TokenId { get => tokenId; set { tokenId = value; base.Id = value; } }

        [JsonPropertyName("amount")]
        public BigInteger Amount { get; set; }

        [JsonPropertyName("minted_block")]
        public BigInteger MintedBlock { get; set; }

        [JsonPropertyName("minted_timestamp")]
        public BigInteger MintedTimestamp { get; set; }

        [JsonPropertyName("minter_address")]
        public string MinterAddress { get; set; }

        private OnFinalityMetadata metadata;
        [JsonPropertyName("metadata")]
        public OnFinalityMetadata Metadata { get => metadata; set
            {
                metadata = value;

                if (value.Name != null)
                {
                    base.Name = value.Name;
                }

                Meta.Name = value.Name;
                Meta.Description = value.Description;
                Meta.Image = value.ImageUri;
            }
        }
    }

}

