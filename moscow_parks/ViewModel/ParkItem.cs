using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moscow_parks.ViewModel
{
    public class ParkItem
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Lat { get; set; }

        [JsonProperty(PropertyName = "lon")]
        public double Lon { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "site")]
        public string Site { get; set; }

        [JsonProperty(PropertyName = "fax")]
        public string Fax { get; set; }

        private string _phone = "";
        [JsonProperty(PropertyName = "phone")]
        public string Phone
        {
            get
            {
                if (_phone != "")
                {
                    return _phone;
                }
                else
                {
                    return "не указан";
                };
            }
            set
            {
            }
        }

        [JsonProperty(PropertyName = "official_address")]
        public string OfficialAddress { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "ao")]
        public string Ao { get; set; }

        private string _image = "";
        public string Image {
            get {
                return "http://moscow-parks.azurewebsites.net/parks/"+this.Id+".jpg";
            }
            set {
                _image = value;
            } 
        }

    }
}
