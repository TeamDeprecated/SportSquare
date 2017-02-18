using SportSquare.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Models.Factories
{
    public interface IUserFactory
    {
        User CreateUser(Guid aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age);
    }
}
