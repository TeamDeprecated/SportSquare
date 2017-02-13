using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models
{
    public class HomeEventArgs : EventArgs
    {
        public HomeEventArgs(string ip)
        {
            if (ip == null)
            {
                throw new ArgumentNullException(nameof(ip));
            }
            this.Ip = ip;
        }

        public string Ip { get; private set; }

    }
}