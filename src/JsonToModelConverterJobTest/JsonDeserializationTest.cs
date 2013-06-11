using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using JsonToModelConverterJob;
using System.IO;
using System.Collections.Generic;

namespace JsonToModelConverterJobTest
{
    [TestClass]
    public class JsonDeserializationTest
    {
        [TestMethod]
        public void SensorMessage_Of_Type_Sensor_Correctly_Deserialized()
        {
            //Arrange

            //Act
            var sensorMessage = JsonConvert.DeserializeObject<Message>(TestData.JsonSensorMessage);

            //Assert
            sensorMessage.ShouldHave().AllProperties().EqualTo(TestData.SensorMessage);
        }

        [TestMethod]
        public void SensorMessage_Of_Type_Status_Correctly_Deserialized()
        {
            //Arrange

            //Act
            var sensorMessage = JsonConvert.DeserializeObject<Message>(TestData.JsonStatusMessage);

            //Assert
            sensorMessage.ShouldHave().AllProperties().EqualTo(TestData.StatusMessage);
        }
    }
}
