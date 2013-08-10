using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moscow_parks.ViewModel
{
    public class ParkItem: ViewModelBase
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

        private string _email = "";
        [JsonProperty(PropertyName = "email")]
        public string Email {
            get
            {
                if (_email != "")
                {
                    return _email;
                }
                else
                {
                    return "не указан";
                };
            }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _site = "";
        [JsonProperty(PropertyName = "site")]
        public string Site {
            get
            {
                if (_site != "")
                {
                    return _site;
                }
                else
                {
                    return "не указан";
                };
            }
            set
            {
                _site = value;
                RaisePropertyChanged("Site");
            }
        }

        private string _fax = "";
        [JsonProperty(PropertyName = "fax")]
        public string Fax
        {
            get
            {
                if (_fax != "")
                {
                    return _fax;
                }
                else
                {
                    return "не указан";
                };
            }
            set
            {
                _fax = value;
                RaisePropertyChanged("Fax");
            }
        }

        private string _phone = "";
        [JsonProperty(PropertyName = "phone")]
        public string Phone
        {
            get
            {
                if ((_phone != "") && (_phone != null))
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
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        private string _officialAddress = "";
        [JsonProperty(PropertyName = "official_address")]
        public string OfficialAddress {
            get
            {
                if (_officialAddress != "")
                {
                    return _officialAddress;
                }
                else
                {
                    return "не указан";
                };
            }
            set
            {
                _officialAddress = value;
                RaisePropertyChanged("OfficialAddress");
            }
        }

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
