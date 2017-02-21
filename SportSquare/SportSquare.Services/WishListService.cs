using SportSquare.Models;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSquare.Data.Contracts;
using SportSquare.Models.Factories;
using Bytes2you.Validation;

namespace SportSquare.Services
{
    public class WishListService : SportSquareGenericService<UserWishVenue>, IWishListService
    {
        private IWishListFactory wishListFactory;
        private IGenericRepository<Venue> venueRepository;
        public WishListService(IGenericRepository<UserWishVenue> repository, IGenericRepository<Venue> venueRepository, IUnitOfWork unitOfWork, IWishListFactory wishListFactory) : base(repository, unitOfWork)
        {
            Guard.WhenArgument(wishListFactory, nameof(wishListFactory)).IsNull().Throw();
            this.wishListFactory = wishListFactory;
            Guard.WhenArgument(venueRepository, nameof(venueRepository)).IsNull().Throw();
            this.venueRepository = venueRepository;

        }

        public void UpdateWishList(Guid user, int venueId)
        {
            UserWishVenue wishList;
            var wishlistExists = this.GetAll(x => x.UserId == user);
            if (wishlistExists.Count() == 0)
            {
                wishList = this.wishListFactory.Create(user);
                var venue = this.venueRepository.GetById(venueId);
                wishList.Venues.Add(venue);
                this.Add(wishList);

            }
            else
            {
                wishList = wishlistExists.First();
                var venue = this.venueRepository.GetById(venueId);
                wishList.Venues.Add(venue);
            this.Update(wishList);
            }

        }
    }
}
