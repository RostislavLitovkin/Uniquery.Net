using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class UniqueCollection : Collection
    {
        [JsonPropertyName("actions_count")]
        public int? Actions_Count { get; set; }

        //[JsonPropertyName("attributes_schema")]
        //public string Attributes_Schema { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("burned")]
        public bool? Burned { get; set; }

        [JsonPropertyName("collection_cover")]
        public string Collection_Cover { get => Meta.Image; set { Meta.Image = value; } }

        [JsonPropertyName("collection_id")]
        public int? Collection_Id { get => int.Parse(Id); set { if (value != null) Id = value.ToString(); } }

        //[JsonPropertyName("const_chain_schema")]
        //public string Const_Chain_Schema { get; set; } // assuming JSON maps to string here

        private List<UniqueNft> tokens = new List<UniqueNft>();

        [JsonPropertyName("tokens")]
        public List<UniqueNft> Tokens { get => tokens; set { if (value != null) { tokens = value; Nfts = new List<Nft>(value); } } }

        [JsonPropertyName("date_of_creation")]
        public int? Date_Of_Creation { get => (int)CreatedAt.ToUniversalTime().Ticks; set { if (value != null) CreatedAt = new DateTime((long)value, DateTimeKind.Utc); } }

        [JsonPropertyName("description")]
        public string Description { get => Meta.Description; set { Meta.Description = value; } }

        [JsonPropertyName("holders_count")]
        public int? Holders_Count { get; set; }

        [JsonPropertyName("limits_account_ownership")]
        public int? Limits_Account_Ownership { get; set; }

        [JsonPropertyName("limits_sponsore_data_rate")]
        public float? Limits_Sponsore_Data_Rate { get; set; }

        [JsonPropertyName("limits_sponsore_data_size")]
        public float? Limits_Sponsore_Data_Size { get; set; }

        [JsonPropertyName("mint_mode")]
        public bool? Mint_Mode { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get => Meta.Name; set { Meta.Name = value; base.Name = value; } }

        [JsonPropertyName("nesting_enabled")]
        public bool? Nesting_Enabled { get; set; }

        [JsonPropertyName("offchain_schema")]
        public string Offchain_Schema { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get => CurrentOwner; set { CurrentOwner = value; } }

        [JsonPropertyName("owner_can_destroy")]
        public bool? Owner_Can_Destroy { get; set; }

        [JsonPropertyName("owner_can_transfer")]
        public bool? Owner_Can_Transfer { get; set; }

        [JsonPropertyName("owner_normalized")]
        public string Owner_Normalized { get; set; }

        //[JsonPropertyName("permissions")]
        //public string Permissions { get; set; } // assuming JSONObject maps to string here

        //[JsonPropertyName("properties")]
        //public string Properties { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("schema_version")]
        public string Schema_Version { get; set; }

        [JsonPropertyName("sponsorship")]
        public string Sponsorship { get; set; }

        [JsonPropertyName("token_limit")]
        public float? Token_Limit { get; set; }

        [JsonPropertyName("token_prefix")]
        public string Token_Prefix { get; set; }

        //[JsonPropertyName("token_property_permissions")]
        //public string Token_Property_Permissions { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("tokens_count")]
        public int? Tokens_Count { get => NftCount; set { NftCount = value; } }

        [JsonPropertyName("transfers_count")]
        public int? Transfers_Count { get; set; }

        //[JsonPropertyName("variable_on_chain_schema")]
        //public string Variable_On_Chain_Schema { get; set; } // assuming JSON maps to string here
    }

}

