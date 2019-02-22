using System;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    public class Person
    {
        // 
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute("FullName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "StreetAddress")]
        public Address Address { get; set; }


    }
}
