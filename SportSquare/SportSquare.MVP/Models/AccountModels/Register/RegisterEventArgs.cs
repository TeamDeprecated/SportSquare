using Bytes2you.Validation;
using SportSquare.Enums;
using System;
using System.Web;

namespace SportSquare.MVP.Models.AccountModels.Register
{
    public class RegisterEventArgs : EventArgs
    {
        

        public RegisterEventArgs(HttpContext context, string email, string passwordHash)
        {
            Guard.WhenArgument(context, nameof(context)).IsNull().Throw();
            Guard.WhenArgument(passwordHash, nameof(passwordHash)).IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, nameof(email)).IsNullOrEmpty().Throw();
            this.Context = context;
            this.Email = email;
            this.PasswordHash = passwordHash;
        }
        public RegisterEventArgs(HttpContext context, string email, string passwordHash, string firstName, string lastName, GenderType gender, string age)
            :this(context,email,passwordHash)
        {

            Guard.WhenArgument(firstName.Length, string.Format("First Name should be between {0} and {1}", 2, 20)).IsLessThan(2).IsGreaterThan(20).Throw();
            Guard.WhenArgument(lastName.Length, string.Format("Last Name should be between {0} and {1}", 2, 20)).IsLessThan(2).IsGreaterThan(20).Throw();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            try
            {
                this.Age = int.Parse(age);
            }
            catch (Exception)
            {
                this.Age = 0;
            }
            
        }


        public HttpContext Context { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public GenderType Gender { get; private set; }
        public int Age { get; private set; }
    }
}