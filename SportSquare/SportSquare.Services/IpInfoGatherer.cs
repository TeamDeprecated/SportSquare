using Newtonsoft.Json;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services
{
    public class IpInfoGatherer :IipInfoGatherer
    {
        private IpInfoGathererModel ipModel;
        public IpInfoGatherer(IpInfoGathererModel model)
        {
            this.ipModel = model;
        }

        public string GetUserCountryByIp(string ip)
        {
            try
            {
                this.CollectIpInfo(ip);
                RegionInfo country = new RegionInfo(this.ipModel.Country);
                ipModel.Country = country.DisplayName;
            }
            catch (Exception)
            {
                ipModel.Country = null;
            }

            return ipModel.Country;
        }

        public string GetUserCityByIp(string ip)
        {
            this.CollectIpInfo(ip);
            return ipModel.City;
        }

        public string[] GetUserCoordinatesByIp(string ip)
        {
            string[] coordinates = new string[2];
            this.CollectIpInfo(ip);
            coordinates = ipModel.Loc.Split(',');
            return coordinates;
        }

        private void CollectIpInfo(string ip)
        {
            string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
            this.ipModel = JsonConvert.DeserializeObject<IpInfoGathererModel>(info);
            //var cityCirilic = new WebClient().DownloadString("http://maps.googleapis.com/maps/api/geocode/json?language=bg&address=" + this.ipModel.City);
            //var test = JsonConvert.DeserializeObject<GoogleLocationModel>(cityCirilic);
        }
    }
}
