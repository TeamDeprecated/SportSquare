using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Contracts
{
    public interface IRatingService
    {
         void AddRating(Guid user, int venue, int Rating);
    }
}
