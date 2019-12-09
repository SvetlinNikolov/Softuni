using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.DataProcessor.ImportDto;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ExportProjectsDto
    {
        [XmlAttribute("TasksCount")]
        public string TasksCount { get; set; }

        [MinLength(2)]
        [MaxLength(40)]
        [Required]
        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportTasksDto[] Tasks { get; set; }
    }
}
