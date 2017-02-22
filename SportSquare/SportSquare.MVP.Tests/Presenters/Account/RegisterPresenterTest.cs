using System;
using NUnit.Framework;
using Moq;
using SportSquare.MVP.Presenters.Account;
using SportSquare.MVP.Views.AccountViews;
using SportSquare.Services.Contracts;
using System.Runtime.Remoting.Contexts;
using System.Web.Routing;
using System.Web;
using System.IO;
using SportSquare.MVP.Models.AccountModels.Register;
using SportSquare.Enums;

namespace SportSquare.MVP.Tests.Presenters.Account
{
    [TestFixture]
    public class RegisterPresenterTest
    {
     [Test]
        public void ConstructorShuldThrowIfUserServiceNull()
        {
            var mockView = new Mock<IRegisterView>();
            Assert.Throws<ArgumentNullException>(() => new RegisterPresenter(mockView.Object, null));
        }
        [Test]
        public void ConstructorShuldCreateInstance()
        {
            var mockView = new Mock<IRegisterView>();
            var mockService = new Mock<IUserService>();
            var actual= new RegisterPresenter(mockView.Object, mockService.Object);

            Assert.IsNotNull(actual);
        }



        [Test]
        public void ConstructorShuldCreateInstanceOfREgisterPresenter()
        {
            var mockView = new Mock<IRegisterView>();
            var mockService = new Mock<IUserService>();
            var actual = new RegisterPresenter(mockView.Object, mockService.Object);

            Assert.IsInstanceOf(typeof(RegisterPresenter), actual);
        }

        //[Test]
        //public void View_RegisterDetailsShouldCallIUserServiceRegisterUser()
        //{
        //    var anystring = "anyString";
        //    var anyInt = 23;
        //    HttpRequest httpRequest = new HttpRequest("", "http://sportsquare.com", "");
        //    StringWriter stringWriter = new StringWriter();
        //    HttpResponse httpResponse = new HttpResponse(stringWriter);
        //    HttpContext httpContextMock = new HttpContext(httpRequest, httpResponse);
        //    var mockedRegisterView = new Mock<IRegisterView>();
        //    var mockedModel = new Mock<RegisterViewModel>();
        //    var mockedservice = new Mock<IUserService>();
        //    mockedRegisterView.Setup(x => x.Model).Returns(mockedModel.Object);
        //    mockedservice.Setup(x => x.RegisterUser(anystring, anystring, anystring, anystring, GenderType.Male, anyInt)).Verifiable();

        //    var registerPresenter = new RegisterPresenter(mockedRegisterView.Object, mockedservice.Object);
        //    mockedRegisterView.Raise(x => x.RegisterDetails += null, new RegisterEventArgs(httpContextMock, anystring, anystring, anystring, anystring, "Male", anystring));
        //    mockedservice.Verify(x => x.RegisterUser(anystring, anystring, anystring, anystring, GenderType.Male, anyInt), Times.Once);
        //}
        //[Test]
        //public void View_RegisterDetailsShouldCallIUserServiceRegisterUserWithCorrectParameters()
        //{
        //    var anystring = "anyString";
        //    var anyInt = 23;
        //    HttpRequest httpRequest = new HttpRequest("", "http://sportsquare.com", "");
        //    StringWriter stringWriter = new StringWriter();
        //    HttpResponse httpResponse = new HttpResponse(stringWriter);
        //    HttpContext httpContextMock = new HttpContext(httpRequest, httpResponse);
        //    var mockedRegisterView = new Mock<IRegisterView>();
        //    var mockedModel = new Mock<RegisterViewModel>();
        //    var mockedservice = new Mock<IUserService>();
        //    mockedRegisterView.Setup(x => x.Model).Returns(mockedModel.Object);
        //    mockedservice.Setup(x => x.RegisterUser(anystring, anystring, anystring, anystring, GenderType.Male, anyInt)).Verifiable();

        //    var registerPresenter = new RegisterPresenter(mockedRegisterView.Object, mockedservice.Object);
        //    mockedRegisterView.Raise(x => x.RegisterDetails += null, new RegisterEventArgs(httpContextMock, anystring, anystring, anystring, anystring, "male", anystring));
        //    mockedservice.Verify(x => x.RegisterUser(It.Is<string>(y=>y==anystring), It.Is<string>(y => y == anystring), It.Is<string>(y => y == anystring), It.Is<string>(y => y == anystring), GenderType.Male, It.Is<int>(y => y == anyInt)), Times.Once);
        //}
    }
}
