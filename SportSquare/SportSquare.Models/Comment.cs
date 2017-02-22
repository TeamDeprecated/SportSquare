using System;
using System.ComponentModel.DataAnnotations.Schema;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class Comment : IDbModel
    {
        public Comment()
        {
            this.Date = DateTime.Now;
            this.IsHidden = false;
        }

        public Comment(Guid userId, int venueId, string description) : this()
        {
            this.VenueId = venueId;
            this.UserId = userId;
            this.Description = description;
        }

        public int Id { get; set; }

        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public bool IsHidden { get; set; }
    }
}
