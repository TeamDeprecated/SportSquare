using System;
using Moq;
using NUnit.Framework;

using SportSquare.Models;
using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;
using SportSquare.Models.Factories;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class CommentServiceTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenRepositoryIsNull()
        {
            // Arrange
            var commentFactory = new Mock<ICommentFactory>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IGenericRepository<Comment> repository = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(repository, unitOfWork.Object, commentFactory.Object));
        }

        [Test]
        public void ConstructorShouldThrowException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var commentFactory = new Mock<ICommentFactory>();
            var repository = new Mock<IGenericRepository<Comment>>();
            IUnitOfWork unitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(repository.Object, unitOfWork, commentFactory.Object));
        }


        [Test]
        public void ConstructorShouldThrowException_WhenCommentFactoryIsNull()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<IGenericRepository<Comment>>();
            ICommentFactory commentFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CommentService(repository.Object, unitOfWork.Object, commentFactory));
        }

        [Test]
        public void ConstructorShouldCreateCommentService_WhenDependenciesAreCorrect()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<Comment>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var commentFactory = new Mock<ICommentFactory>();

            // Act
            ICommentService commentService = new CommentService(repository.Object, unitOfWork.Object, commentFactory.Object);

            // Assert
            Assert.IsNotNull(commentService);
        }
    }
}
