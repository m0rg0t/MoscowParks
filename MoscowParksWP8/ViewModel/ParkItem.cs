﻿using GalaSoft.MvvmLight;
using GART.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoscowParksWP8.ViewModel
{
    public class ParkItem : ViewModelBase
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

        public GeoCoordinate Position
        {
            private set
            {
            }
            get
            {
                return new GeoCoordinate(this.Lat, this.Lon);
            }
        }

        private Visibility _emailVisibility;
        public Visibility EmailVisibility
        {
            get
            {
                return _emailVisibility;
            }
            set
            {
                _emailVisibility = value;
                RaisePropertyChanged("EmailVisibility");
            }
        }
        private string _email = "";
        [JsonProperty(PropertyName = "email")]
        public string Email
        {
            get
            {
                if (_email != "")
                {
                    EmailVisibility = Visibility.Visible;
                    return _email;
                }
                else
                {
                    EmailVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _email = value.Trim();
                RaisePropertyChanged("Email");
            }
        }

        private Visibility _siteVisibility;
        public Visibility SiteVisibility
        {
            get { return _siteVisibility; }
            set
            {
                _siteVisibility = value;
                RaisePropertyChanged("SiteVisibility");
            }
        }

        private string _site = "";
        [JsonProperty(PropertyName = "site")]
        public string Site
        {
            get
            {
                if (_site != "")
                {
                    SiteVisibility = Visibility.Visible;
                    return _site;
                }
                else
                {
                    SiteVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _site = value.Trim();
                RaisePropertyChanged("Site");
            }
        }

        private Visibility _FaxVisibility;
        public Visibility FaxVisibility
        {
            get { return _FaxVisibility; }
            set
            {
                _FaxVisibility = value;
                RaisePropertyChanged("FaxVisibility");
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
                    FaxVisibility = Visibility.Visible;
                    return _fax;
                }
                else
                {
                    FaxVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _fax = value.Trim();
                RaisePropertyChanged("Fax");
            }
        }

        private Visibility _PhoneVisibility;
        public Visibility PhoneVisibility
        {
            get { return _PhoneVisibility; }
            set
            {
                _PhoneVisibility = value;
                RaisePropertyChanged("PhoneVisibility");
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
                    PhoneVisibility = Visibility.Visible;
                    return _phone;
                }
                else
                {
                    PhoneVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _phone = value.Trim();
                RaisePropertyChanged("Phone");
            }
        }

        private Visibility _OfficialAddressVisibility;
        public Visibility OfficialAddressVisibility
        {
            get { return _OfficialAddressVisibility; }
            set
            {
                _OfficialAddressVisibility = value;
                RaisePropertyChanged("OfficialAddressVisibility");
            }
        }
        private string _officialAddress = "";
        [JsonProperty(PropertyName = "official_address")]
        public string OfficialAddress
        {
            get
            {
                if (_officialAddress != "")
                {
                    OfficialAddressVisibility = Visibility.Visible;
                    return _officialAddress;
                }
                else
                {
                    OfficialAddressVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _officialAddress = value.Trim();
                RaisePropertyChanged("OfficialAddress");
            }
        }

        private Visibility _DistrictVisibility;
        public Visibility DistrictVisibility
        {
            get { return _DistrictVisibility; }
            set
            {
                _DistrictVisibility = value;
                RaisePropertyChanged("DistrictVisibility");
            }
        }
        private string _district = "";
        [JsonProperty(PropertyName = "district")]
        public string District
        {
            get
            {
                if (_district != "")
                {
                    DistrictVisibility = Visibility.Visible;
                    return _district;
                }
                else
                {
                    DistrictVisibility = Visibility.Collapsed;
                    return "не указан";
                };
            }
            set
            {
                _district = value.Trim();
                RaisePropertyChanged("District");
            }
        }

        [JsonProperty(PropertyName = "ao")]
        public string Ao { get; set; }

        private string _image = "";
        public string Image
        {
            get
            {
                return "/Assets/parks/" + this.Id + ".jpg";
            }
            set
            {
                _image = value;
                RaisePropertyChanged("Image");
                RaisePropertyChanged("ImageUri");
            }
        }

        private Uri _imageUri;
        /// <summary>
        /// 
        /// </summary>
        public Uri ImageUri
        {
            get
            {
                _imageUri = new Uri("/Asssts/parks/" + this.Id + ".jpg", UriKind.Relative);
                return _imageUri;
            }
            set
            {
                _imageUri = value;
            }
        }


    }
}
