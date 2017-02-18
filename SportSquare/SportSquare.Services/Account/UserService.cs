using SportSquare.Auth;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SportSquare.Enums;
using SportSquare.Models;
using SportSquare.Data.Contracts;
using AutoMapper;
using SportSquareDTOs;

namespace SportSquare.Services.Account
{
    public class UserService: IUserService
    {
        private readonly IGenericRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork)
        {
            if (repository==null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDTO> FilterUsers(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
           return  Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(this.repository.GetAll());
            
        }

        public bool RegisterUser(string email, Guid AspNetUserId, string firstName, string lastName, GenderType gender, int age)
        {
            var user = new User();
            user.Email = email;
            user.AspNetUserId = AspNetUserId;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Gender = gender;
            user.Age = age;
            try
            {
                using (this.unitOfWork)
                {
                    this.repository.Add(user);
                    this.unitOfWork.Commit();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
