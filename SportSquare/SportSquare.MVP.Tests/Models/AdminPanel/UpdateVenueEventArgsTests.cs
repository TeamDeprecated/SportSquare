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
    public class UpdateVenueEventArgsTests
    {
        //const object id = "1";
        const double latitude = 43.2;
        const double longitude = 21.2;
        const string name = "John Dowe";
        const string phone = "293298130";
        const string webAddress = "www.sportsqaure.tk";
        const string address = "Malinov 33";
        const string city = "Sofia";
        const string image = "bestpicture";

        [Test]
        public void ConstructorCreate_NewInstance()
        {
            var actualInstance = new UpdateVenueEventArgs(1,latitude,longitude,name,phone,webAddress,address,city,image);
            Assert.That(actualInstance, Is.Not.Null);
        }

        [Test]
        public void ConstructorCreateCorectly_NewInstanceOfSameType()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.IsInstanceOf(typeof(BasicEventArgs), actualInstance);
        }

        [Test]
        public void ConstructorSetcorrectyId()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(1, actualInstance.Id);
            
        }
        [Test]
        public void ConstructorSetcorrectyLatitude()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(latitude, actualInstance.Latitude);
        }
        [Test]
        public void ConstructorSetcorrectyName()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(name, actualInstance.Name);
        }
        [Test]
        public void ConstructorSetcorrectyPhone()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(phone, actualInstance.Phone);
        }
        [Test]
        public void ConstructorSetcorrectyWebAddress()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(webAddress, actualInstance.WebAddress);
        }
        [Test]
        public void ConstructorSetcorrectyAddress()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(address, actualInstance.Address);
        }
        [Test]
        public void ConstructorSetcorrectyCity()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(city, actualInstance.City);
        }
        [Test]
        public void ConstructorSetcorrectyImage()
        {
            var actualInstance = new UpdateVenueEventArgs(1, latitude, longitude, name, phone, webAddress, address, city, image);
            Assert.AreEqual(image, actualInstance.Image);
        }
    }
}
