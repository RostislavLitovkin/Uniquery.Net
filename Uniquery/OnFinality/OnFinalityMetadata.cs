using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public class OnFinalityMetadata
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("metadata_uri")]
        public string MetadataUri { get; set; }

        [JsonPropertyName("raw")]
        public object Raw { get; set; } // It's unclear what AnyJson translates to in C#. Depending on the contents, it might need to be a class or a different type.

        [JsonPropertyName("metadata_status")]
        public OnFinalityStatusType MetadataStatus { get; set; } // Assuming StatusType is an enum or class you have already defined.

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("token_uri")]
        public string TokenUri { get; set; }

        [JsonPropertyName("image_uri")]
        public string ImageUri { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}

