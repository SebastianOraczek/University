using System;
using System.Text.Json.Serialization;

namespace Lab9_WPF
{
    public class SnippetReponse
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}
