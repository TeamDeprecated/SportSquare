using System.Collections.Generic;

using SportSquare.Models;
using SportSquare.Services.Contracts;

namespace SportSquare.Services
{
    public interface ICommentService : ISportSquareGenericService<Comment>
    {
        IEnumerable<Comment> GetAllCommentsByVenueId(int id);

        IEnumerable<Comment> GetAllCommentsByUserId(int id);

        Comment GetLastCommentByVenueId(int id);
    }
}