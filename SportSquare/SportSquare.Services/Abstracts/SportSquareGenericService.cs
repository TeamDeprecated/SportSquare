using System;

using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;

namespace SportSquare.Services
{
    public abstract class SportSquareGenericService<T>:ISportSquareGenericSerivce<T> where T: class
    {
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;

        public SportSquareGenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("Repository cannot be null!");
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
