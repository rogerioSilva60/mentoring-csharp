using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace RestWithASPNET.Data.VO
{
    public class PersonVO
    {
        [XmlElement("code")]
        [JsonPropertyName("code")]
        public long Id { get; set; }
        
        [XmlElement("name")]
        [JsonPropertyName("name")]
        public string FirstName { get; set; }
        
        [XmlElement("last_name")]
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string Address { get; set; }

        [XmlElement("gender")]
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }
}
