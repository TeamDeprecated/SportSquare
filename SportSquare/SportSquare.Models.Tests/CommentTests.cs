using Moq;
using NUnit.Framework;
using System;

namespace SportSquare.Models.Tests
{
    [TestFixture]
    public class CommentTests
    {
        [Test]
        public void ParameterlessConstructor_MustCreateComment()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.IsInstanceOf<Comment>(comment);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_IdProperty()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.AreEqual(0, comment.Id);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_VenueId()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.AreEqual(0, comment.VenueId);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_UserId()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.AreEqual(new Guid(), comment.UserId);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_Description()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.AreEqual(null, comment.Description);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_Date()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.IsFalse(comment.IsHidden);
        }

        [Test]
        public void ParameterlessConstructor_MustNotSet_IsHiddenProperty()
        {
            // Arrange & Act
            var comment = new Comment();

            // Assert
            Assert.IsFalse(comment.IsHidden);
        }

        [Test]
        public void ConstructorWithParams_MustCreateComment()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.IsInstanceOf<Comment>(comment);
        }

        [Test]
        public void ConstructorWithParams_MustNotSet_IdProperty()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.AreEqual(0, comment.Id);
        }

        [Test]
        public void ConstructorWithParams_MustSet_VenueId()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.AreEqual(venueId, comment.VenueId);
        }

        [Test]
        public void ConstructorWithParams_MustSet_UserId()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.AreEqual(userId, comment.UserId);
        }

        [Test]
        public void ConstructorWithParams_MustSet_Description()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.AreEqual(description, comment.Description);
        }

        [Test]
        public void ConstructorWithParams_MustSet_Date()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.IsNotNull(description, comment.Description);
        }

        [Test]
        public void ConstructorWithParams_MustSet_IsHiddenProp()
        {
            // Arrange & Act
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";

            var comment = new Comment(userId, venueId, description);

            // Assert
            Assert.IsFalse(comment.IsHidden);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void IsHiddenShouldGetAndSetCorrectly(bool option)
        {
            // Arrange 
            var userId = Guid.NewGuid();
            var venueId = 1;
            string description = "test";
            var comment = new Comment(userId, venueId, description);

            //Act
            comment.IsHidden = option;

            // Assert
            Assert.AreEqual(option, comment.IsHidden);
        }
    }
}
