using System;
using System.Linq;
using System.Collections.Generic;

using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Models.Factories;

namespace SportSquare.Services.Contracts
{
    public class CommentService : SportSquareGenericService<Comment>, ICommentService
    {
        private ICommentFactory commentFactory;

        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork, ICommentFactory commentFactory) : base(repository, unitOfWork)
        {
            if (commentFactory == null)
            {
                throw new ArgumentNullException("Comment cant't be null");
            }

            this.commentFactory = commentFactory;
        }
        
        // TODO To Implement!
        public void CreateComment(string aspNetUserId, int venueId, string description)
        {
            var userGuid = Guid.Parse(aspNetUserId);

            var comment = this.commentFactory.CreateComment(userGuid, venueId, description);

            this.Add(comment);
        }

        // TODO Test it works && edit (int) id!
        public void UpdateComment(int commentId, string userId, string description)
        {
            var userGuid = Guid.Parse(userId);

            var comment = this.Repository.GetById(commentId);

            if (comment.UserId != userGuid)
            {
                throw new ArgumentException("This user is not author of this comment!");
            }

            comment.Description = description ?? comment.Description;
            comment.Date = DateTime.Now;

            this.Update(comment);
        }

        // TODO Test it works && edit (int) id!
        public Comment GetLastCommentByVenueId(int id)
        {
            return this.Repository.GetAll(c => c.IsHidden == false && c.VenueId == (int)id, c => c.Date).FirstOrDefault();
        }

        public IEnumerable<Comment> GetAllCommentsByVenueId(int id)
        {
            return this.Repository.GetAll(c => c.IsHidden == false && c.VenueId == (int)id);
        }

        public IEnumerable<Comment> GetAllCommentsByUserId(string id)
        {
            var userGuid = Guid.Parse(id);

            return this.Repository.GetAll(c => c.UserId == userGuid && c.IsHidden == false);
        }
    }
}
