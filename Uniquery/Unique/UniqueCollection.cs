using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class UniqueCollection
    {
        [JsonPropertyName("actions_count")]
        public int Actions_Count { get; set; }

        //[JsonPropertyName("attributes_schema")]
        //public string Attributes_Schema { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("burned")]
        public bool Burned { get; set; }

        [JsonPropertyName("collection_cover")]
        public string Collection_Cover { get; set; }

        [JsonPropertyName("collection_id")]
        public int Collection_Id { get; set; }

        //[JsonPropertyName("const_chain_schema")]
        //public string Const_Chain_Schema { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("date_of_creation")]
        public int? Date_Of_Creation { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("holders_count")]
        public int Holders_Count { get; set; }

        [JsonPropertyName("limits_account_ownership")]
        public int? Limits_Account_Ownership { get; set; }

        [JsonPropertyName("limits_sponsore_data_rate")]
        public float? Limits_Sponsore_Data_Rate { get; set; }

        [JsonPropertyName("limits_sponsore_data_size")]
        public float? Limits_Sponsore_Data_Size { get; set; }

        [JsonPropertyName("mint_mode")]
        public bool Mint_Mode { get; set; }

        [JsonPropertyName("mode")]
        public string Mode { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nesting_enabled")]
        public bool Nesting_Enabled { get; set; }

        [JsonPropertyName("offchain_schema")]
        public string Offchain_Schema { get; set; }

        [JsonPropertyName("owner")]
        public string Owner { get; set; }

        [JsonPropertyName("owner_can_destroy")]
        public bool Owner_Can_Destroy { get; set; }

        [JsonPropertyName("owner_can_transfer")]
        public bool Owner_Can_Transfer { get; set; }

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
        public float Token_Limit { get; set; }

        [JsonPropertyName("token_prefix")]
        public string Token_Prefix { get; set; }

        //[JsonPropertyName("token_property_permissions")]
        //public string Token_Property_Permissions { get; set; } // assuming JSON maps to string here

        [JsonPropertyName("tokens_count")]
        public int Tokens_Count { get; set; }

        [JsonPropertyName("transfers_count")]
        public int Transfers_Count { get; set; }

        //[JsonPropertyName("variable_on_chain_schema")]
        //public string Variable_On_Chain_Schema { get; set; } // assuming JSON maps to string here

        public override string ToString()
        {
            return "Unique collection: " + Name + " by " + Owner + " (id: " + Collection_Id + ")"
                + Description + "\n";
        }
    }

}

