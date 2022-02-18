namespace ScryfallAPI
{
    using Newtonsoft.Json;
    using System;

    public class Set
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("mtgo_code")]
        public string MTGOCode { get; set; }

        [JsonProperty("tcgplayer_id")]
        public int? TCGPlayerId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("scryfall_uri")]
        public Uri ScryfallUri { get; set; }

        [JsonProperty("search_uri")]
        public Uri SearchUri { get; set; }

        [JsonProperty("released_at")]
        public DateTime? ReleasedAt { get; set; }

        [JsonProperty("set_type")]
        public string SetType { get; set; }

        [JsonProperty("card_count")]
        public int CardCount { get; set; }

        [JsonProperty("digital")]
        public bool Digital { get; set; }

        [JsonProperty("nonfoil_only")]
        public bool NonFoilOnly { get; set; }

        [JsonProperty("foil_only")]
        public bool FoilOnly { get; set; }

        [JsonProperty("icon_svg_uri")]
        public Uri IconSVGUri { get; set; }

        [JsonProperty("block_code")]
        public string BlockCode { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("parent_set_code")]
        public string ParentSetCode { get; set; }

        [JsonProperty("printed_size")]
        public int? PrintedSize { get; set; }

        protected bool HasParent => !ParentSetCode.IsNullOrDefault();
    }
}
