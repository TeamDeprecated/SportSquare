using System;

namespace SportSquare.Models.Factories
{
    public interface ICommentFactory
    {
        Comment CreateComment(Guid userId, int venueId, string description);
    }
}
