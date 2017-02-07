using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Contracts
{
    public interface IipInfoGatherer
    {
        string GetUserCountryByIp(string ip);
        string GetUserCityByIp(string ip);
        string[] GetUserCoordinatesByIp(string ip);
    }
}
