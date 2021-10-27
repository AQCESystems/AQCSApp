using Newtonsoft.Json;
namespace AQCSApp.Common.Models
{
    public class FishFamily
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}{this.Name}";
        }
    }
}
