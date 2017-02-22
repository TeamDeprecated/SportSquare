using System;

using SportSquare.Enums;

namespace SportSquare.Models.Factories
{
    public interface IUserFactory
    {
        User CreateUser(Guid aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age);
    }
}
