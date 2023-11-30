﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class ExportXmlTruckDto
    {
        [XmlElement("RegistrationNumber")]
        public string RegistrationNumber { get; set; } = null!;

        [XmlElement("Make")]
        public string MakeType { get; set; } = null!;
    }
}
