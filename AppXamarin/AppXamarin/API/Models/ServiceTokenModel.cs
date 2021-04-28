using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.API.Models
{
    public class ServiceTokenModel
    {
        
        [JsonProperty(PropertyName = "access_token")]
        public string access_token { get; set; }
    }
}
