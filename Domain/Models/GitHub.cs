using Newtonsoft.Json;
using System;

namespace Domain.Models
{
    public class GitHub
    {
        // For AutoMapper
        public GitHub() { }

        // For Tests
        public GitHub(int id, int idGitHub, string name, string uRL, string language, string description, DateTime dtAtualizacao, string donoRepositorio, bool favorite)
        {
            Id = id;
            IdGitHub = idGitHub;
            Name = name;
            URL = uRL;
            Language = language;
            Description = description;
            DtAtualizacao = dtAtualizacao;
            DonoRepositorio = donoRepositorio;
            Favorite = favorite;
        }

        public int Id { get; }

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

        [JsonProperty("owner/login")]
        public string DonoRepositorio { get; private set; }

        public bool Favorite { get; private set; }

        public void ToogleBookmark()
        {
            Favorite = !Favorite;
        }
    }
}