using Cinema.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportHallsAndSeatsDto
    {
     
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Is4Dx")]
        public bool Is4Dx { get; set; }

        [JsonProperty("Is3D")]
        public bool Is3D { get; set; }

        [Range(1, int.MaxValue)]
        [JsonProperty("Seats")]
        public int Seats { get; set; }
    }
}
