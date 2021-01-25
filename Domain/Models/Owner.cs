using Newtonsoft.Json;

namespace Domain.Models
{
    public class Owner
    {
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("login")]
        public string Login { get; private set; }
    }
}
