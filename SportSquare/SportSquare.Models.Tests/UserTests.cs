using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using SportSquare.Enums;
using SportSquare.Models.Contracts;

namespace SportSquare.Models.Tests
{

    [TestFixture]
    public class UserTests
    {
        [Test]
        public void ConstructorWithParams_MustCreateUser()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;

            // Act
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.IsInstanceOf<User>(user);
        }

        [Test]
        public void ConstructorWithParam_MustSetIsHiddenToFalse()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(false, user.IsHidden);
        }


        [Test]
        public void ConstructorWithParam_MustCreateCommentCollectionWhenInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.IsNotNull(user.Comments);
        }

        [Test]
        public void ConstructorWithParam_MustCreateFavoriteVenuesWhenInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.IsNotNull(user.FavoriteVenues);
        }

        [Test]
        public void ConstructorWithParam_MustCreateRatingCollectionWhenInit()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.IsNotNull(user.Ratings);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_ID()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(userId, user.Id);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_Email()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_Firstname()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(firstname, user.FirstName);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_LastName()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(lastname, user.LastName);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_Gender()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(gender, user.Gender);
        }

        [Test]
        public void ConstructorWithParam_MustSetCorrectlyHisInitProp_Age()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var email = "mail@cvb.bacm";
            var firstname = "gogo";
            var lastname = "gogov";
            var gender = GenderType.Female;
            var age = 17;
            var user = new User(userId, email, firstname, lastname, gender, age);

            // Assert
            Assert.AreEqual(age, user.Age);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateUser()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNotNull(user);
        }

        [Test]
        public void ParameterlessConstructor_MustSetIsHiddenToFalse()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.AreEqual(false, user.IsHidden);
        }


        [Test]
        public void ParameterlessConstructor_MustCreateCommentCollectionWhenInit()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNotNull(user.Comments);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateFavoriteVenuesWhenInit()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNotNull(user.FavoriteVenues);
        }

        [Test]
        public void ParameterlessConstructor_MustCreateRatingCollectionWhenInit()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNotNull(user.Ratings);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetEmail()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNull(user.Email);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetFirstName()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNull(user.FirstName);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetLastName()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNull(user.LastName);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetGender()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.AreEqual(0,(int)user.Gender);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetAge()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.AreEqual(0, user.Age);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSetId()
        {
            // Arrange & Act
            var user = new User();

            // Assert
            Assert.IsNotNull(user.Id);
        }


        [Test]
        public void IsUserImplementHisInterfaces()
        {
            // Act & Arrange & Assert
            Assert.IsNotNull(typeof(User).GetInterfaces().SingleOrDefault(i => i == typeof(IDbModel)));
        }

        [Test]
        public void UserPropertyId_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var id = Guid.NewGuid();

            // Act
            user.Id = id;

            // Assert
            Assert.AreEqual(id, user.Id);
        }

        [Test]
        public void UserPropertyFirstName_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var firstName = "gogo";

            // Act
            user.FirstName = firstName;

            // Assert
            Assert.AreEqual(firstName, user.FirstName);
        }

        [Test]
        public void UserPropertyLastName_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var lastname = "gogo";

            // Act
            user.LastName = lastname;

            // Assert
            Assert.AreEqual(lastname, user.LastName);
        }

        [Test]
        public void UserPropertyGender_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var gender = GenderType.Female; ;

            // Act
            user.Gender = gender;

            // Assert
            Assert.AreEqual(gender, user.Gender);
        }

        [Test]
        public void UserPropertyAge_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var age = 15;

            // Act
            user.Age = age;

            // Assert
            Assert.AreEqual(age, user.Age);
        }

        [Test]
        public void UserPropertyEmail_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var email = "uvas@abv.bg";

            // Act
            user.Email = email;

            // Assert
            Assert.AreEqual(email, user.Email);
        }

        [Test]
        public void UserPropertyRatings_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var ratings = new HashSet<Rating>();

            // Act
            user.Ratings = ratings;

            // Assert
            Assert.AreEqual(ratings, user.Ratings);
        }

        [Test]
        public void UserPropertyFavoriteVenues_MustBeSetCorectly()
        {
            // Arrange
            var user = new User();
            var favoriteVenues = new HashSet<UserFavoriteVenue>();

            // Act
            user.FavoriteVenues = favoriteVenues;

            // Assert
            Assert.AreEqual(favoriteVenues, user.FavoriteVenues);
        }
    }
}

