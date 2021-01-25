using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class GitHub
    {
        public int Id { get; private set; }

        [JsonProperty("id")]
        public int IdGitHub { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("url")]
        public string URL { get; private set; }

        [JsonProperty("language")]
        public string Language { get; private set; }

        [JsonProperty("description")]
        public string Description { get; private set; }

        [JsonProperty("updated_at")]
        public DateTime DtAtualizacao { get; private set; }

        [NotMapped]
        [JsonProperty("owner")]
        public Owner DonoRepositorio { get; private set; }
        public bool Favorite { get; private set; }

        public void ToogleBookmark()
        {
            Favorite = !Favorite;
        }
    }
}
