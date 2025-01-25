using Newtonsoft.Json;

namespace WebUI.Models.DTOs.Category
{
    public class CategoryDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
