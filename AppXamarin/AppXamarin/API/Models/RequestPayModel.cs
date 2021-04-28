using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Models
{
    public class RequestPayModel
    {
        [JsonProperty(PropertyName = "sender_batch_header")]
        public BatchHeaderModel sender_batch_header { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<ItemsModel> items { get; set; }
    }
}
