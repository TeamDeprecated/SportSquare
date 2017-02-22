using System;
using Moq;
using NUnit.Framework;

using SportSquare.Models;
using SportSquare.Data.Contracts;
using SportSquare.Services.Contracts;
using SportSquare.Models.Factories;
using SportSquare.Enums;

namespace SportSquare.Services.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [Test]
        public void ConstructorShouldThrowException_WhenRepositoryIsNull()
        {
            // Arrange
            var userFactory = new Mock<IUserFactory>();
            var unitOfWork = new Mock<IUnitOfWork>();
            IGenericRepository<User> repository = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository, unitOfWork.Object, userFactory.Object));
        }

        [Test]
        public void ConstructorShouldThrowException_WhenUnitOfWorkIsNull()
        {
            // Arrange
            var userFactory = new Mock<IUserFactory>();
            var repository = new Mock<IGenericRepository<User>>();
            IUnitOfWork unitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository.Object, unitOfWork, userFactory.Object));
        }


        [Test]
        public void ConstructorShouldThrowException_WhenUserFactoryIsNull()
        {
            // Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var repository = new Mock<IGenericRepository<User>>();
            IUserFactory userFactory = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(repository.Object, unitOfWork.Object, userFactory));
        }

        [Test]
        public void ConstructorShouldCreateUserService_WhenDependenciesAreCorrect()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();

            // Act
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);

            // Assert
            Assert.IsNotNull(userService);
        }
        [Test]
        public void ConstructorShouldCreateUserService_InstanceWhenDependenciesAreCorrect()
        {
            // Arrange
            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();

            // Act
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);

            // Assert
            Assert.AreEqual(typeof(UserService), userService.GetType());
        }


        [Test]
        public void RegisterUserShouldCallUSerFactoryCreateUserOnce()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameUserId()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(It.Is<Guid>(y=>y==mockedGuid), anyString, anyString, anyString, GenderType.Male, anyInt), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameEmail()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser( mockedGuid, It.Is<string>(y => y == anyString), anyString, anyString, GenderType.Male, anyInt), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameFirstName()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(mockedGuid,  anyString, It.Is<string>(y => y == anyString), anyString, GenderType.Male, anyInt), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameLastName()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(mockedGuid, anyString,  anyString, It.Is<string>(y => y == anyString), GenderType.Male, anyInt), Times.Once);
        }
        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameGender()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, It.Is<GenderType>(y => y.Equals( GenderType.Male)), anyInt), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallUSerFactoryWithSameAge()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Verifiable();

            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            userFactory.Verify(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, It.Is<int>(y => y == anyInt)), Times.Once);
        }

        [Test]
        public void RegisterUserShouldCallGenericServiceAddOnce()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            var fakedUser = new User();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Returns(fakedUser);
            var generickService = new Mock<ISportSquareGenericService<User>>();
            repository.Setup(x => x.Add(fakedUser)).Verifiable();
            
           userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            repository.Verify(x => x.Add(fakedUser), Times.Once);

        }

        [Test]
        public void RegisterUserShouldCallGenericServiceAddWithSameUserFromFactory()
        {
            string anyString = "Kot takoava";
            int anyInt = 23;
            var mockedGuid = Guid.Parse("E56F7468-AC9B-454C-A73E-E687DFC925B1");
            var mockedGuidString = "E56F7468-AC9B-454C-A73E-E687DFC925B1";

            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            var fakedUser = new User();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            userFactory.Setup(x => x.CreateUser(mockedGuid, anyString, anyString, anyString, GenderType.Male, anyInt)).Returns(fakedUser);
            repository.Setup(x => x.Add(fakedUser)).Verifiable();


            userService.RegisterUser(mockedGuidString, anyString, anyString, anyString, GenderType.Male, anyInt);
            repository.Verify(x => x.Add(It.Is<User>(y=>y==fakedUser)), Times.Once);

        }

        [Test]
        public void GetAllUsersShouldCallGenericRepostioryGetAllOnce()
        {
            var repository = new Mock<IGenericRepository<User>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var userFactory = new Mock<IUserFactory>();
            var fakedUser = new User();
            IUserService userService = new UserService(repository.Object, unitOfWork.Object, userFactory.Object);
            repository.Setup(x => x.GetAll()).Verifiable();


            userService.GetAll();

            repository.Verify(x => x.GetAll(), Times.Once);
        }

        }
}
