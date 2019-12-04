using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportUsersDto
    {
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+")]
        [Required]
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [MinLength(3)]
        [MaxLength(20)]
        [Required]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Range(3, 103)]
        [Required]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [JsonProperty("Cards")]
        [MinLength(1)]
        public ICollection<ImportCardsDto> Cards { get; set; } = new HashSet<ImportCardsDto>();
    }
}
