using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
   
    public class ImportGamesDto
    {
        [JsonProperty("Name")]
        [Required]
        public string Name { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        [JsonProperty("Price")]
        public decimal Price { get; set; }

        [Required]
        [JsonProperty("ReleaseDate")]
        public string ReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string Developer { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [MinLength(1)]
        [JsonProperty("Tags")]
        public ICollection<string> Tags { get; set; } = new HashSet<string>();

    }
}
