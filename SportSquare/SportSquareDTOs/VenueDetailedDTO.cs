using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs
{
    public class VenueDetailedDTO: VenueDTO
    {
        public IEnumerable<CommentDTO> Comments { get; set; }
    }
}
