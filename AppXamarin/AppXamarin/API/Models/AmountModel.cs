using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Models
{
    public class AmountModel
    {
        [JsonProperty(PropertyName = "value")]
        public string value { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }
    }
}
