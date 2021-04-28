using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Models
{
    public class ItemsModel
    {
        [JsonProperty(PropertyName = "recipient_type")]
        public string recipient_type { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public AmountModel amount { get; set; }

        [JsonProperty(PropertyName = "receiver")]
        public string receiver { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string note { get; set; }

        [JsonProperty(PropertyName = "sender_item_id")]
        public string sender_item_id { get; set; }
        
    }
}
