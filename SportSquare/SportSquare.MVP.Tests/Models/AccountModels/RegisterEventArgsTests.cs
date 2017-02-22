using System;
using NUnit.Framework;
using SportSquare.MVP.Models.AccountModels.Register;
using Moq;
using System.Web;
using SportSquare.Enums;
using System.IO;

namespace SportSquare.MVP.Tests.Models.AccountModels
{
    [TestFixture]
    public class RegisterEventArgsTests
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
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs(null, mockedString, mockedString));
            Assert.AreEqual("The argument is null.\r\nParameter name: context", ex.Message);
        }

        [Test]
        public void ConstructorThrowsIfNullEmialIsPassed()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs(httpContextMock, null, mockedString));
            Assert.AreEqual("The argument is null or an empty string.\r\nParameter name: email", ex.Message);

        }
        [Test]
        public void ConstructorThrowsIfNullPassHashIsPassed()
        {
         
            var ex = Assert.Throws<ArgumentNullException>(() => new RegisterEventArgs(httpContextMock, mockedString, null));
            Assert.AreEqual("The argument is null or an empty string.\r\nParameter name: passwordHash", ex.Message);
        }

        [Test]
        public void RegisterEventArgsInalizedCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString);
            Assert.That(actualInstance, Is.Not.Null);
        }
        [Test]
        public void RegisterEventArgsConstructorOverloadInalizedCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString, mockedString, mockedString, mockedString, mockedString);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void ConstructorSetContextCorectly()
        {
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString);
            Assert.AreEqual(httpContextMock, actualInstance.Context);
        }

        [Test]
        public void ConstructorSetEmailCorectly()
        {
            var email = "my@email.com";
            var actualInstance = new RegisterEventArgs(httpContextMock, email, mockedString);
            Assert.AreEqual(email, actualInstance.Email);
        }
        [Test]
        public void ConstructorSetPassHashCorectly()
        {
            var pashHash = "randomText12_";
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, pashHash);
            Assert.AreEqual(pashHash, actualInstance.PasswordHash);
        }
        [Test]
        public void ConstructorSetFirstNameCorectly()
        {
            var firstName = "MyName";
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString, firstName, mockedString, mockedString, mockedString);
            Assert.AreEqual(firstName, actualInstance.FirstName);
        }

        [Test]
        public void ConstructorSetLastNameCorectly()
        {
            var lastName = "MyName";
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString, mockedString, lastName, mockedString, mockedString);
            Assert.AreEqual(lastName, actualInstance.LastName);
        }

        [Test]
        public void ConstructorSetGenderCorectly()
        {
            var gender = "male";
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString, mockedString, mockedString, gender, mockedString);
            Assert.AreEqual(gender, actualInstance.Gender);
        }

        [Test]
        public void ConstructorSetAgeCorectly()
        {
            var age = "42";
            var actualInstance = new RegisterEventArgs(httpContextMock, mockedString, mockedString, mockedString, mockedString, mockedString, age);
            Assert.AreEqual(int.Parse(age), actualInstance.Age);
        }

    }
}

