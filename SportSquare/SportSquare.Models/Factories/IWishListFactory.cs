using System;

namespace SportSquare.Models.Factories
{
    public interface IWishListFactory
    {
        UserWishVenue Create(Guid user);
    }
}
