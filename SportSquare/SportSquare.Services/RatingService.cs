using SportSquare.Models;
using SportSquare.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportSquare.Data.Contracts;
using SportSquare.Models.Factories;

namespace SportSquare.Services
{
    public class RatingService :SportSquareGenericService<Rating>, IRatingService
    {
        private IRatingFactory raitingFacgory;
        public RatingService(IGenericRepository<Rating> repository, IUnitOfWork unitOfWork,IRatingFactory ratingFactory) 
            : base(repository, unitOfWork)
        {
            this.raitingFacgory = ratingFactory;
        }

        public void AddRating(string user, int venue, int rating)
        {
            Guid userGuid;
            Guid.TryParse(user, out userGuid);
            this.Add(this.raitingFacgory.Create(userGuid, venue, rating));
        }
    }
}
