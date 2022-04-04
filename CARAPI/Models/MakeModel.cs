using Newtonsoft.Json;

namespace CARAPI.Models
{
    public class MakeModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("make")]
        public string Make{ get; set; }
    }
}
