using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
   
   public class ExportUsersDto
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Tasks")]
        public ExportTasksDtoo[] Tasks { get; set; }
    }
}
