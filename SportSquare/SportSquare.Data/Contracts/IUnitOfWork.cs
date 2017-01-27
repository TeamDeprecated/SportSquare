using System;

namespace SportSquare.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {

        void Commit();
    }
}
