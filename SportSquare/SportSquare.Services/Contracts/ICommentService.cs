using System.Collections.Generic;
using SportSquare.Models;
using SportSquare.Services.Contracts;

namespace SportSquare.Services
{
    public interface ICommentService : ISportSquareGenericService<Comment>
    {
        void CreateComment(int userId, int venueID, string description);

        void UpdateComment(int commentId, int userId, string description);

        Comment GetLastCommentByVenueId(int id);

        IEnumerable<Comment> GetAllCommentsByVenueId(int id);

        IEnumerable<Comment> GetAllCommentsByUserId(int id);
    }
}