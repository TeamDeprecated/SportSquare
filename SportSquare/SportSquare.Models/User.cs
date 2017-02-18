using System.Collections.Generic;

using SportSquare.Enums;
using SportSquare.Models.Contracts;
using System;

namespace SportSquare.Models
{
    public class User : IDbModel
    {
        // TODO: Must be added validations!

        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;
        private ICollection<UserFavoriteVenue> favoriteVenues;
        private ICollection<UserWishVenue> wishVenues;

        public User()
        {
            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
            this.favoriteVenues = new HashSet<UserFavoriteVenue>();
            this.wishVenues = new HashSet<UserWishVenue>();
        }

        public User(Guid aspNetUserId, string username) : this()
        {
            this.AspNetUserId = aspNetUserId;
            this.Username = username;
        }

        public int Id { get; set; }

        public Guid AspNetUserId { get; set; }

        public string Username { get; set; }

        //public string Username { get; set; }

        //[MinLength(2)]
        //[MaxLength(10)]
        public string FirstName { get; set; }

        //[MinLength(2)]
        //[MaxLength(10)]
        public string LastName { get; set; }

        public GenderType Gender { get; set; }

       public int Age { get; set; }

        //[Required]
        //[EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<UserFavoriteVenue> FavoriteVenues
        {
            get { return this.favoriteVenues; }
            set { this.favoriteVenues = value; }
        }

        public virtual ICollection<UserWishVenue> WishVenues
        {
            get { return this.wishVenues; }
            set { this.wishVenues = value; }
        }

        public bool IsHidden { get; set; }
    }
}