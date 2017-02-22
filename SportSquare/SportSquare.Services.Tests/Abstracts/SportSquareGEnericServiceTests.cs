using Moq;
using NUnit.Framework;
using SportSquare.Data.Contracts;
using SportSquare.Data.Repositories;
using SportSquare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Services.Tests.Abstracts
{
    [TestFixture]
    class SportSquareGEnericServiceTests
    {
        [Test]
        public void ConstructorShoulDThrowIfRepositoryIsNull()
        {
            var mockedUnitOfWork= new Mock<IUnitOfWork>();
            Assert.Throws<ArgumentNullException>(() => new SportSqaureGenericServiceMock(null, mockedUnitOfWork.Object));
        }
        [Test]
        public void ConstructorShoulDThrowIfUnitOfWorkIsNull()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            Assert.Throws<ArgumentNullException>(() => new SportSqaureGenericServiceMock(mockeRepository.Object,null));
        }

        [Test]
        public void AddSholdCallRepositoryAddOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();

            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Add(fakeUser)).Verifiable();
            genericService.Add(fakeUser);
            mockeRepository.Verify(x => x.Add(fakeUser), Times.Once);
        }

        [Test]
        public void AddSholdCallRepositoryAddWithSameUser()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Add(fakeUser)).Verifiable();
            genericService.Add(fakeUser);
            mockeRepository.Verify(x => x.Add(It.Is<User>(y=>y== fakeUser)), Times.Once);
        }

        [Test]
        public void AddSholdCallUnitOfWorkComitOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            genericService.Add(new User());
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void UpdateSholdCallRepositoryUpdateOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();

            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Update(fakeUser)).Verifiable();
            genericService.Update(fakeUser);
            mockeRepository.Verify(x => x.Update(fakeUser), Times.Once);
        }

        [Test]
        public void UpdateSholdCallRepositoryUpdateWithSameUser()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Update(fakeUser)).Verifiable();
            genericService.Update(fakeUser);
            mockeRepository.Verify(x => x.Update(It.Is<User>(y => y == fakeUser)), Times.Once);
        }

        [Test]
        public void UpdateSholdCallUnitOfWorkComitOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            genericService.Update(new User());
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void HideSholdCallRepositoryHideOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Hide(fakeUser)).Verifiable();
            genericService.Hide(fakeUser);
            mockeRepository.Verify(x => x.Hide(fakeUser), Times.Once);
        }

        [Test]
        public void HideSholdCallRepositoryHideWithSameUser()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Hide(fakeUser)).Verifiable();
            genericService.Hide(fakeUser);
            mockeRepository.Verify(x => x.Hide(It.Is<User>(y => y == fakeUser)), Times.Once);
        }

        [Test]
        public void HideSholdCallUnitOfWorkComitOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            genericService.Hide(new User());
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        [Test]
        public void DeleteSholdCallRepositoryDeleteOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();

            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Delete(fakeUser)).Verifiable();

            genericService.Delete(fakeUser);
            mockeRepository.Verify(x => x.Delete(fakeUser), Times.Once);
        }

        [Test]
        public void DeleteSholdCallRepositoryDeleteWithSameUser()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var fakeUser = new User();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.Delete(fakeUser)).Verifiable();
            genericService.Delete(fakeUser);
            mockeRepository.Verify(x => x.Delete(It.Is<User>(y => y == fakeUser)), Times.Once);
        }

        [Test]
        public void DeleteSholdCallUnitOfWorkComitOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockedUnitOfWork.Setup(x => x.Commit()).Verifiable();
            genericService.Delete(new User());
            mockedUnitOfWork.Verify(x => x.Commit(), Times.Once);
        }
        [Test]
        public void GetByIdShouldCallRepositoryGetByIdOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetById(1)).Verifiable();
            genericService.GetById(1);
            mockeRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Test]
        [TestCase(1)]
        [TestCase(42)]
        [TestCase(876)]
        [TestCase(1000)]
        public void GetByIdShouldCallRepositoryGetByIdOnceWithSameId(int fakeId)
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetById(fakeId)).Verifiable();
            genericService.GetById(fakeId);
            mockeRepository.Verify(x => x.GetById(It.Is<int>(y=>y== fakeId)), Times.Once);
        }

        [Test]
        public void GetAllShouldCallRepositoryGetAllOnce()
        {
            var mockeRepository = new Mock<IGenericRepository<User>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();
            var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
            mockeRepository.Setup(x => x.GetAll()).Verifiable();
            genericService.GetAll();
            mockeRepository.Verify(x => x.GetAll(), Times.Once);
        }


        // TODO Tested till hiden!
        //[Test]
        //public void GetHidenShouldCallRepositoryGetHidenOnce()
        //{
        //    var mockeRepository = new Mock<IGenericRepository<User>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
        //    mockeRepository.Setup(x => x.GetAll(ent => ent.IsHidden)).Verifiable();
        //    genericService.GetHidden();
        //    mockeRepository.Verify(x => x.GetAll(ent => ent.IsHidden), Times.Once);
        //}

        //[Test]
        //public void GetHidenShouldCallRepositoryGetHidenWhereAllHiden()
        //{
        //    var mockeRepository = new Mock<IGenericRepository<User>>();
        //    var mockedUnitOfWork = new Mock<IUnitOfWork>();
        //    var genericService = new SportSqaureGenericServiceMock(mockeRepository.Object, mockedUnitOfWork.Object);
        //    mockeRepository.Setup(x => x.GetAll()).Verifiable();
        //    genericService.GetHidden();
        //    mockeRepository.Verify(x => x.GetAll(It.Is<>), Times.Once);
        //}






    }
}
