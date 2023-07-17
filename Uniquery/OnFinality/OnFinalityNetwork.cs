using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
	public class OnFinalityNetwork
	{
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}

