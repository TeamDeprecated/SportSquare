using NUnit.Framework;
using SportSquare.MVP.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SportSquare.MVP.Tests.Models.AccountModels
{
    [TestFixture]
    class LoginEventArgsTests
    {


        HttpContext httpContextMock;
        const string mockedString = "string";

        [SetUp]
        public void Init()
        {
            HttpRequest httpRequest = new HttpRequest("", "http://mySomething/", "");
            StringWriter stringWriter = new StringWriter();
            HttpResponse httpResponse = new HttpResponse(stringWriter);
            this.httpContextMock = new HttpContext(httpRequest, httpResponse);
        }
        [TearDown]
        public void RunAfterAnyTest()
        {
            this.httpContextMock = null;
        }
        [Test]
        public void ConstructorThrowsIfNullContextIsPassed()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs(null, mockedString, mockedString, false));
            Assert.AreEqual("The argument is null.\r\nParameter name: context", ex.Message);
        }

        [Test]
        public void ConstructorThrowsIfNullEmialIsPassed()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs(httpContextMock, null, mockedString, false));
            Assert.AreEqual("The argument is null or an empty string.\r\nParameter name: email", ex.Message);

        }
        [Test]
        public void ConstructorThrowsIfNullPassHashIsPassed()
        {

            var ex = Assert.Throws<ArgumentNullException>(() => new LoginEventArgs(httpContextMock, mockedString, null, false));
            Assert.AreEqual("The argument is null or an empty string.\r\nParameter name: passwordHash", ex.Message);
        }








        [Test]
        public void LoginEventArgsInalizedCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new LoginEventArgs(httpContextMock, mockedString, mockedString, false);
            Assert.That(actualInstance, Is.Not.Null);
        }
  

        [Test]
        public void ConstructorSetContextCorectly()
        {
            var actualInstance = new LoginEventArgs(httpContextMock, mockedString, mockedString, false);
            Assert.AreEqual(httpContextMock, actualInstance.Context);
        }

        [Test]
        public void ConstructorSetEmailCorectly()
        {
            var email = "my@email.com";
            var actualInstance = new LoginEventArgs(httpContextMock, email, mockedString, false);
            Assert.AreEqual(email, actualInstance.Email);
        }
        [Test]
        public void ConstructorSetPassHashCorectly()
        {
            var pashHash = "randomText12_";
            var actualInstance = new LoginEventArgs(httpContextMock, mockedString, pashHash, false);
            Assert.AreEqual(pashHash, actualInstance.PasswordHash);
        }
        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void ConstructorSetRememberMePropertyCorectly( bool rememberMe)
        {
            var actualInstance = new LoginEventArgs(httpContextMock, mockedString, mockedString, rememberMe);
            Assert.AreEqual(rememberMe, actualInstance.RememberMeChecked);
        }

    }
}
