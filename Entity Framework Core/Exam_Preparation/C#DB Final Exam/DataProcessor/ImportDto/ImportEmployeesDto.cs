using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeesDto
    {

        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression("(^[A-z0-9]+)$")]
        [JsonProperty("Username")]
        public string Username { get; set; }

        [Required]
        [JsonProperty("Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("(^[0-9]{3}-[0-9]{3}-[0-9]{4})$")]
        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Tasks")]
        public string[] Tasks { get; set; }
    }
}
