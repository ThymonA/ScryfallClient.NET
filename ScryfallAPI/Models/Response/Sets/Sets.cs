namespace ScryfallAPI
{
    using Newtonsoft.Json;

    using System.Collections.Generic;

    public class Sets
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("data")]
        public List<Set> Data { get; set; }
    }
}
