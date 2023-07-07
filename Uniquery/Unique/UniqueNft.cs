using System;
using System.Diagnostics;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Uniquery
{
    public class UniqueNft : Nft
    {
        //[JsonPropertyName("attributes")]
        //public string Attributes { get; set; }

        [JsonPropertyName("bundle_created")]
        public int? Bundle_Created { get; set; }

        [JsonPropertyName("burned")]
        public bool? Burned { get; set; }

        [JsonPropertyName("children_count")]
        public int? Children_Count { get; set; }

        [JsonPropertyName("collection_cover")]
        public string Collection_Cover { get => Collection.Image; set { Collection.Image = value; } }

        [JsonPropertyName("collection_description")]
        public string Collection_Description { get => Meta.Description; set { Meta.Description = value; } }

        [JsonPropertyName("collection_id")]
        public int? Collection_Id { get => int.Parse(Collection.Id); set { if (value != null) { Collection.Id = value.ToString(); } } }

        [JsonPropertyName("collection_name")]
        public string Collection_Name { get => Collection.Name; set { Collection.Name = value; } }

        [JsonPropertyName("collection_owner")]
        public string Collection_Owner { get => Collection.CurrentOwner; set { Collection.CurrentOwner = value; } }

        [JsonPropertyName("collection_owner_normalized")]
        public string Collection_Owner_Normalized { get; set; }

        [JsonPropertyName("date_of_creation")]
        public int? Date_Of_Creation { get => (int)CreatedAt.ToUniversalTime().Ticks; set { if (value != null) CreatedAt = new DateTime((long)value, DateTimeKind.Utc); } }

        private UniqueImage image;
        [JsonPropertyName("image")]
        public UniqueImage Image { get => image; set { image = value; Meta.Image = value.FullUrl; } }

        [JsonPropertyName("is_sold")]
        public bool? Is_Sold { get; set; }

        [JsonPropertyName("nested")]
        public bool? Nested { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get => CurrentOwner; set { CurrentOwner = value; } }

        [JsonPropertyName("owner_normalized")]
        public string Owner_Normalized { get; set; }

        [JsonPropertyName("parent_id")]
        public string Parent_Id { get; set; }

        //[JsonPropertyName("properties")]
        //public string Properties { get; set; }

        [JsonPropertyName("token_id")]
        public int? Token_Id { get { int result; if (int.TryParse(Id.AsSpan(), out result)) return result; return null; } set { if (value != null) Id = value.ToString(); } }

        [JsonPropertyName("token_name")]
        public string Token_Name { get => Name; set { Name = value; Meta.Name = value; } }

        [JsonPropertyName("token_prefix")]
        public string Token_Prefix { get; set; }

        [JsonPropertyName("tokensOwners")]
        public string TokensOwners { get; set; }

        [JsonPropertyName("tokens_amount")]
        public string Tokens_Amount { get; set; }

        [JsonPropertyName("tokens_owner")]
        public string Tokens_Owner { get; set; }

        [JsonPropertyName("tokens_parent")]
        public string Tokens_Parent { get; set; }

        [JsonPropertyName("total_pieces")]
        public string Total_Pieces { get; set; }

        [JsonPropertyName("transfers_count")]
        public int? Transfers_Count { get; set; }
    }

}

