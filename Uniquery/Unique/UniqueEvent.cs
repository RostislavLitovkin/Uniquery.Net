using System;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace Uniquery
{
	public class UniqueEvent
	{
        [JsonPropertyName("block_index")]
        public string Block_Index { get; set; }

        [JsonPropertyName("block_number")]
        public string Block_Number { get; set; }

        [JsonPropertyName("collection_id")]
        public int? Collection_Id { get; set; }

        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("section")]
        public string Section { get; set; }

        [JsonPropertyName("token_id")]
        public int? Token_Id { get; set; }

        public override string ToString()
        {
            return "Rmrk event: " + Method + " - " + Block_Number + "\n";
        }
    }
}

