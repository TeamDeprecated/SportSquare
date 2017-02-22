using System;
using NUnit.Framework;
using Moq;
using SportSquare.MVP.Views.AccountViews;
using SportSquare.MVP.Presenters.Account;
using SportSquare.Services.Contracts;

namespace SportSquare.MVP.Tests.Presenters
{
    [TestFixture]
    public class LoginPresenterTest
    {

   
        [Test]
        public void ConstructorShuldCreateInstance()
        {
            var mockView = new Mock<ILoginView>();
            var mockService = new Mock<IUserService>();
            var actual = new LoginPresenter(mockView.Object);

            Assert.IsNotNull(actual);
        }



        [Test]
        public void ConstructorShuldCreateInstanceOfREgisterPresenter()
        {
            var mockView = new Mock<ILoginView>();
            var mockService = new Mock<IUserService>();
            var actual = new LoginPresenter(mockView.Object);

            Assert.IsInstanceOf(typeof(LoginPresenter), actual);
        }

    }
}
