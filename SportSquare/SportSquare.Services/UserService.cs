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
using SportSquare.Models.Factories;

namespace SportSquare.Services.Account
{
    public class UserService: SportSquareGenericService<User>, IUserService
    {
        private IUserFactory userFactory;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserFactory userfactory, IUserFactory userFactory) : base(repository, unitOfWork)
        {
            if (userFactory == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            this.userFactory = userfactory;
        }

        public IEnumerable<UserDTO> FilterUsers(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
           return  Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(this.Repository.GetAll());
            
        }

        public bool RegisterUser(string email, Guid aspNetUserId, string firstName, string lastName, GenderType gender, int age)
        {
            var user = this.userFactory.CreateUser(email, aspNetUserId, firstName, lastName, gender, age);
     
            try
            {
                using (this.UnitOfWork)
                {
                    this.Repository.Add(user);
                    this.UnitOfWork.Commit();
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
