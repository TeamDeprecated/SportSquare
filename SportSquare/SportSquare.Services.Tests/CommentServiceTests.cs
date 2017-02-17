using System;
using Moq;
using NUnit.Framework;

using SportSquare.Models;
using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class CommentServiceTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenRepositoryIsNull()
        {
            // Arrange
            IGenericRepository<Comment> repository = null;
            var unitOfWork = new Mock<IUnitOfWork>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(repository, unitOfWork.Object));
        }

        [Test]
        public void ConstructorShouldThrowException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<Comment>>();
            IUnitOfWork unitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(repository.Object, unitOfWork));
        }

        [Test]
        public void ConstructorShouldCreateCommentService_WhenDependenciesAreCorrect()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<Comment>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            // Act
            ICommentService commentService = new CommentService(repository.Object, unitOfWork.Object);

            // Assert
            Assert.IsNotNull(commentService);
        }
    }
}
