using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.AccountModels.Register
{
    public class RegisterViewModel
    {
        public string ErrorMessage { get; internal set; }
        public bool Succeeded { get; internal set; }
    }
}