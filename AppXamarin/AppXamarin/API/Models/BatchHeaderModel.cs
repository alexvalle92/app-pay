using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Models
{
    public class BatchHeaderModel
    {
        [JsonProperty(PropertyName = "email_subject")]
        public string email_subject { get; set; }

        [JsonProperty(PropertyName = "sender_batch_id")]
        public string sender_batch_id { get; set; }
    }
}
