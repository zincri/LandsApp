﻿namespace Lands.Models
{
    using Newtonsoft.Json;
    public class Language
    {
        #region Properties
        [JsonProperty(PropertyName = "iso639_1")]
        public string Iso639_1 { get; set; }
        [JsonProperty(PropertyName = "iso639_2")]
        public string Iso639_2 { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "nativeName")]
        public string NativeName { get; set; }
        #endregion
        public Language()
        {
        }
    }
}
