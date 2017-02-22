using System.Collections.Generic;

using SportSquare.Enums;
using SportSquare.Models;
using SportSquareDTOs;

namespace SportSquare.Services.Contracts
{
    public interface IUserService : ISportSquareGenericService<User>
    {
        IEnumerable<UserDTO> GetAllUsers();

        IEnumerable<UserDTO> FilterUsers(string filter);

        bool RegisterUser(string aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age);
    }
}
