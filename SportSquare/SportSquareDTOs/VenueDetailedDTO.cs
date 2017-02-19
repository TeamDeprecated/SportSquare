using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs
{
    public class VenueDetailedDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public IEnumerable<VenueTypeDTO> VenueTypes { get; set; }
        public IEnumerable<CommentDTO> Comments { get; set; }

        public string WebAddress { get; set; }
        public double RatingAvarage { get; set; }

    }
}
