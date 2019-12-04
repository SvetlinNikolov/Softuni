using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportCardsDto
    {
        [RegularExpression(@"^([0-9]{4}) ([0-9]{4}) ([0-9]{4}) ([0-9]{4})$")]
        [Required]
        [JsonProperty("Number")]
        public string Number { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{3})$")]
        [JsonProperty("CVC")]
        public string Cvc { get; set; }

        [Required]
        [JsonProperty("Type")]
        public CardType Type { get; set; }
    }
}
