using System;
using System.Web;

namespace SportSquare.MVP.Models.AccountModels.Register
{
    public class RegisterEventArgs : EventArgs
    {
        

        public RegisterEventArgs(HttpContext context, string email, string passwordHash)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (passwordHash == null)
            {
                throw new ArgumentNullException(nameof(passwordHash));
            }
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }
            this.Context = context;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }

        public  HttpContext Context { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
    }
}