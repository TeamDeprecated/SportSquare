using System.Collections.Generic;
using SportSquare.Models;
using SportSquare.Services.Contracts;
using System;

namespace SportSquare.Services
{
    public interface ICommentService : ISportSquareGenericService<Comment>
    {
        void CreateComment(Guid userId, int venueID, string description);

        void UpdateComment(int commentId, Guid userId, string description);

        Comment GetLastCommentByVenueId(int id);

        IEnumerable<Comment> GetAllCommentsByVenueId(int id);

        IEnumerable<Comment> GetAllCommentsByUserId(string id);
    }
}