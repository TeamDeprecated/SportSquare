using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models
{
    public class HomeEventArgs : EventArgs
    {
        public string Ip { get; private set; }
        public HomeEventArgs(string ip)
        {
            this.Ip = ip;
        }
    }
}