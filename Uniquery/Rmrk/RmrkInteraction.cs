using System;
using System.Text.Json.Serialization;

namespace Uniquery
{
    public enum RmrkInteraction
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

        [JsonPropertyName("CHANGEISSUER")]
        ChangeIssuer,

        [JsonPropertyName("EMOTE")]
        Emote
    }
}

