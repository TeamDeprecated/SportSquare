using System;
using System.Linq;
using System.Collections.Generic;

using SportSquare.Data.Contracts;
using SportSquare.Models;

namespace SportSquare.Services.Contracts
{
    public class CommentService : SportSquareGenericService<Comment>, ICommentService
    {
        private IGenericRepository<Comment> repository;

        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("Repository cant't be null");
            }

            this.repository = repository;
        }
        
        // TODO To Implement!
        public void CreateComment(int userId, int venueID, string description)
        {
            throw new NotImplementedException();
        }

        // TODO Test it works && edit (int) id!
        public void UpdateComment(int commentId, int userId, string description)
        {
            var comment = this.repository.GetById(commentId);

            if (comment.UserId != userId)
            {
                throw new ArgumentException("This user is not author of this comment!");
            }

            comment.Description = description;
            comment.Date = DateTime.Now;

            this.repository.Update(comment);
        }

        // TODO Test it works && edit (int) id!
        public Comment GetLastCommentByVenueId(int id)
        {
            return this.repository.GetAll(c => c.IsHidden == false && c.VenueId == (int)id, c => c.Date).FirstOrDefault();
        }

        public IEnumerable<Comment> GetAllCommentsByVenueId(int id)
        {
            return this.repository.GetAll(c => c.IsHidden == false && c.VenueId == (int)id);
        }

        public IEnumerable<Comment> GetAllCommentsByUserId(int id)
        {
            return this.repository.GetAll(c => c.UserId == id && c.IsHidden == false);
        }
    }
}
