using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class UniqueImage
	{
        [JsonPropertyName("fullUrl")]
        public string FullUrl { get; set; }

        [JsonPropertyName("ipfsCid")]
        public string IpfsCid { get; set; }
    }
}

