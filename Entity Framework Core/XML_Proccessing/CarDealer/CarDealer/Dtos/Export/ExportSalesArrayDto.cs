using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("sale")]
    public class ExportSalesArrayDto
    {
        [XmlElement("car")]
        public ExportSalesWithDiscountDto Sales { get; set; }
    }
}
