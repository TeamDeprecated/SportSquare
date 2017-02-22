using Moq;
using NUnit.Framework;
using SportSquare.MVP.Models.AdminPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.MVP.Tests.Models.AdminPanel
{
    [TestFixture]
    public class BasicEventArgsTests
    {

        [Test]
        public void BasicEventArgsTestsCorectly_NewInstanceIsCreated()
        {
            var actualInstance = new BasicEventArgs(It.IsAny<string>());
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void BasicEventArgsTestsCorectly_NewInstanceIsCreatedOfSameType()
        {
            var actualInstance = new BasicEventArgs(It.IsAny<string>());
            Assert.IsInstanceOf(typeof(BasicEventArgs),actualInstance);
        }


        [Test]
        [TestCase("0")]
        [TestCase(100)]
        public void BasicEventArgsIdCanBeGetedAndIsSame(object id)
        {
            var actualInstance = new BasicEventArgs(id);
            Assert.AreEqual(actualInstance.Id, id);
        }
    }
}
