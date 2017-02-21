using SportSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Contracts
{
    public interface IWishListService :ISportSquareGenericService<UserWishVenue>
    {
        void UpdateWishList(Guid user,int venue);
    }
}
