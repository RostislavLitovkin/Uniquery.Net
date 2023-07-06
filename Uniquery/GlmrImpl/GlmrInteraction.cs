using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniquery.GlmrImpl
{
    public enum GlmrInteraction
    {
        [JsonPropertyName("MINT")]
        Mint,

        [JsonPropertyName("MINTNFT")]
        MintNft,

        [JsonPropertyName("LIST")]
        List,

        [JsonPropertyName("UNLIST")]
        Unlist,

        [JsonPropertyName("BUY")]
        Buy,

        [JsonPropertyName("SEND")]
        Send,

        [JsonPropertyName("CONSUME")]
        Consume,
    }
}
