﻿using SportSquare.Auth;
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

namespace SportSquare.Services
{
    public class UserService: SportSquareGenericService<User>, IUserService
    {
        private IUserFactory userFactory;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserFactory userFactory) : base(repository, unitOfWork)
        {
            if (userFactory == null)
            {
                throw new ArgumentNullException(nameof(userFactory));
            }

            this.userFactory = userFactory;
        }

        public bool RegisterUser(string aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age)
        {
            var userGuid = Guid.Parse(aspNetUserId);

            var user = this.userFactory.CreateUser(userGuid, email, firstName, lastName, gender, age);

            try
            {
                this.Add(user);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public IEnumerable<UserDTO> FilterUsers(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
           return  Mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(this.Repository.GetAll());
        }
    }
}
