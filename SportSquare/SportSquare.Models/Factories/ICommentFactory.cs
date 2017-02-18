using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Models.Factories
{
    public interface ICommentFactory
    {
        Comment CreateComment(Guid aspNetuserId, int venueId, string description);
    }
}
