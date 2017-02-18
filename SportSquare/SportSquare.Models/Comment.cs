﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class Comment : IDbModel
    {
        // TODO: Must be added validations!
        public Comment()
        {
        }

        public Comment(int venueId, int userId, string description)
        {
            this.VenueId = venueId;
            this.UserId = userId;
            this.Description = description;
            this.Date = DateTime.Now;
        }

        public int Id { get; set; }

        public int VenueId { get; set; }

        public virtual Venue Venue { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }

        public bool IsHidden { get; set; }
    }
}
