using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    [JsonArray("Tasks")]
    public class ExportTasksDtoo
    {
        //TaskName": "Columbian",
        //"OpenDate": "10/24/2018",
        //"DueDate": "10/20/2019",
        //"LabelType": "Hibernate",
        //"ExecutionType": "InProgress"

            [JsonProperty("TaskName")]
        public string TaskName { get; set; }

        [JsonProperty("OpenDate")]
        public string OpenDate { get; set; }

        [JsonProperty("DueDate")]
        public string DueDate { get; set; }

        [JsonProperty("LabelType")]
        public string LabelType { get; set; }

        [JsonProperty("ExecutionType")]
        public string ExecutionType { get; set; }
    }
}
