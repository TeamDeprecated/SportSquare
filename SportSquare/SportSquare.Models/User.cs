using System;
using System.Collections.Generic;

using SportSquare.Enums;
using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class User : IDbModel
    {
        private ICollection<Comment> comments;
        private ICollection<UserFavoriteVenue> favoriteVenues;
        private ICollection<Rating> ratings;
        private ICollection<UserWishVenue> wishVenues;

        public User()
        {
            this.comments = new HashSet<Comment>();
            this.favoriteVenues = new HashSet<UserFavoriteVenue>();
            this.ratings = new HashSet<Rating>();
            this.wishVenues = new HashSet<UserWishVenue>();
            this.IsHidden = false;
        }

        public User(Guid aspNetUserId, string email, string firstName, string lastName, GenderType gender, int age)
            : this()
        {
            this.Id = aspNetUserId;
            this.Username = email;
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
            this.Age = age;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

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


        public virtual UserWishVenue UserWishVenue { get; set; }

        public bool IsHidden { get; set; }
    }
}