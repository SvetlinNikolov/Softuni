using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("parts")]
    public class PartsDto
    {
        [XmlElement("partId")]
        public ImportPartsIdDto[] PartsId { get; set; }
    }
}

