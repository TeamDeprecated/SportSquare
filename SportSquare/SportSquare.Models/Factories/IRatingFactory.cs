using System;

namespace SportSquare.Models.Factories
{
    public interface IRatingFactory
    {
        Rating Create(Guid user, int venueId, int rate);
    }
}
