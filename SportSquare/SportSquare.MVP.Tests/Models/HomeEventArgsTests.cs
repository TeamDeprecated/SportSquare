using System;
using NUnit.Framework;
using SportSquare.MVP.Models;
using Moq;

namespace SportSquare.MVP.Tests.Models
{
    [TestFixture]
    public class HomeEventArgsTests
    {
        const string HomeEventArgsExceptionMessage = "Value cannot be null.\r\nParameter name: ip";

        [Test]
        public void HomeEventArgsConstructorThrowsIfNullIsPassed()
        {
            Assert.Throws<ArgumentNullException>(()=>new HomeEventArgs(null));
        }

        [Test]
        public void HomeEventArgsConstructorThrowsCorrectMessageIfNullIsPassed()
        {
           var ex= Assert.Throws<ArgumentNullException>(() => new HomeEventArgs(null));
            Assert.That(ex.Message, Is.EqualTo(HomeEventArgsExceptionMessage));
        }

        [Test]
        public void HomeEventArgsInalizedCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new HomeEventArgs("");
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void HomveEventArgsIpPropertyCanBeGetedAndItIsSame()
        {
            const string ip = "87.10.12.76";
            var actualInstance = new HomeEventArgs(ip);
            Assert.AreEqual(actualInstance.Ip,ip);
        }
    }
}
