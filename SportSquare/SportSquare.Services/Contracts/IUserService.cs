using SportSquare.Enums;
using SportSquare.Models;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetAllUsers();
        IEnumerable<UserDTO> FilterUsers(string filter);
        bool RegisterUser(Guid aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age);
    }
}
