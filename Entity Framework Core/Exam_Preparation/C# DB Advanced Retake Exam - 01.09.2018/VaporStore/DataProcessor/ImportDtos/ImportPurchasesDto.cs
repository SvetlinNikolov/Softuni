using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    [XmlType("Purchase")]
    public class ImportPurchasesDto
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("Key")]
        [RegularExpression("^([A-Z0-9]{4})-([A-Z0-9]{4})-([A-Z0-9]{4})$")]
        [Required]
        public string Key { get; set; }

        [XmlElement("Card")]
        [RegularExpression(@"^([0-9]{4}) ([0-9]{4}) ([0-9]{4}) ([0-9]{4})$")]
        [Required]
     
        public string Card { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }
    }
}
