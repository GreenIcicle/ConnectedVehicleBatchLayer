using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JsonToModelConverterJob;
using JsonToModelConverterJob.Extensions;

namespace JsonToModelConverterJobTest
{
    [TestClass]
    public class MappingExtensionsTest
    {
        [TestMethod]
        public void MapToDelivery_Using_Status_Message()
        {
            //Arrange

            //Act
            var delivery = new[] { TestData.StatusMessage }.GroupBy(msg => msg.DeliveryId).First().MapToDelivery();

            //Assert
            Assert.AreEqual(TestData.StatusMessage.Position.Latitude, delivery.PositionHistory.Single().Geolocation.Latitude);
        }
    }
}
