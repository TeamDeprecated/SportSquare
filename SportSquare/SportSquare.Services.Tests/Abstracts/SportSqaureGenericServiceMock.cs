using SportSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSquare.Data.Contracts;

namespace SportSquare.Services.Tests.Abstracts
{
    class SportSqaureGenericServiceMock : SportSquareGenericService<User>
    {
        public SportSqaureGenericServiceMock(IGenericRepository<User> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
