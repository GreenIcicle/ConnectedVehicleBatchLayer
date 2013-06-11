using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonToModelConverterJob;

namespace JsonToModelConverterJobTest
{
    [TestClass]
    public class JsonDeserializationTest
    {
        private const string JsonSensorMessage = 
                @"{
                  'type' : 'Sensor',
                  'vid' : 'ZE_1000',
                  'coordinate' : {
                    'latitude' : 51.51288025731022,
                    'longitude' : 7.467044022649306
                  },
                  'timestamp' : 1000,
                  'sequence' : 2,
                  'speed' : 6.48,
                  'fuel' : 48.0,
                  'kilometer' : 0.0018,
                  'temperature' : 102.43999481201172,
                  'pressure' : 2.5999999046325684
                }";

        private const string JsonStatusMessage =
             @"{
                 'type' : 'Status',
                 'vid' : 'ZE_1000',
                 'coordinate' : {
                   'latitude' : 51.51289,
                   'longitude' : 7.46606
                 },
                 'timestamp' : 0,
                 'sequence' : 1,
                 'info' : 'START',
                 'deliveryId' : 1
               }";

        [TestMethod]
        public void SensorMessage_Of_Type_Sensor_Correctly_Deserialized()
        {
            //Arrange
            var expectedMessage = new SensorMessage
            {
                Type = "Sensor",
                Id = "ZE_1000",
                Position = new Position
                {
                    Latitude = 51.51288025731022,
                    Longitude = 7.467044022649306
                },

                Timestamp = 1000,
                Sequence = 2,
                Speed = 6.48,
                Fuel = 48.0,
                Kilometer = 0.0018,
                Temperature = 102.43999481201172,
                Pressure = 2.5999999046325684
            };

            //Act
            var sensorMessage = JsonConvert.DeserializeObject<SensorMessage>(JsonSensorMessage);

            //Assert
            sensorMessage.ShouldHave().AllProperties().EqualTo(expectedMessage);
        }

        [TestMethod]
        public void SensorMessage_Of_Type_Status_Correctly_Deserialized()
        {
            //Arrange
            var expectedMessage = new SensorMessage
            {
                Type = "Status",
                Id = "ZE_1000",
                Position = new Position
                {
                    Latitude = 51.51289,
                    Longitude = 7.46606
                },
                Info = "START",
                DeliveryId = 1,
                Timestamp = 0,
                Sequence = 1
            };

            //Act
            var sensorMessage = JsonConvert.DeserializeObject<SensorMessage>(JsonStatusMessage);

            //Assert
            sensorMessage.ShouldHave().AllProperties().EqualTo(expectedMessage);
        }
    }
}
