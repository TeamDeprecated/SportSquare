using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services
{
    public class SportSquareGenericService<T>:ISportSquareGenericSerivce<T> where T: class
    {
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;

        public SportSquareGenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("Repostiory cannot be null!");
            }
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("UnitOfWork cannot be null!");
            }
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }
    }
}
