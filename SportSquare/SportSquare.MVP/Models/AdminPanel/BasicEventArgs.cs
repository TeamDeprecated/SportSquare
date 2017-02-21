using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.AdminPanel
{
    public class BasicEventArgs : EventArgs
    {
        public object Id { get; set; }

        public BasicEventArgs(object id)
        {
            this.Id = id;
        }
    }
}