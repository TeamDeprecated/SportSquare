using System;
using System.Collections.Generic;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Data.Repositories;

namespace SportSquare.Services.Contracts
{
    public class CommentService : SportSquareGenericService<Comment>, ICommentService
    {
        private IGenericRepository<Comment> repository;
        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.repository = repository;
        }

        public IEnumerable<Comment> GetAllCommentsByUserId(int id)
        {
            return this.repository.GetAll(c => c.UserId == id);
        }

        public IEnumerable<Comment> GetAllCommentsByVenueId(int id)
        {
            return this.repository.GetAll(c => c.VenueId == id);
        }

        // I'm not sure is this working!
        public Comment GetLastCommentByVenueId(int id)
        {
            return this.repository.GetAll(c => c.VenueId == id, order => order.Date).GetEnumerator().Current;
        }
    }
}
