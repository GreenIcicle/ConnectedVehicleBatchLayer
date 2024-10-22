﻿using JsonToModelConverterJob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonToModelConverterJobTest
{
    internal class TestData
    {
        public const string JsonSensorMessage =
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

        public static readonly Message SensorMessage = new Message
        {
            Type = MessageType.SENSOR,
            VehicleId = "ZE_1000",
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

        public const string JsonStatusMessage =
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

        public static readonly Message StatusMessage = new Message
        {
            Type = MessageType.STATUS,
            VehicleId = "ZE_1000",
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
    }
}
