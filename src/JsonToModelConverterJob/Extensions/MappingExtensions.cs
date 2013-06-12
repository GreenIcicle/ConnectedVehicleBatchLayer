using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zuehlke.Camp2013.ConnectedVehicles;

namespace JsonToModelConverterJob.Extensions
{
    public static class MappingExtensions
    {
        public static Delivery MapToDelivery(this IGrouping<int, Message> groupedMessages)
        {
            var delivery = new Delivery();

            if(!groupedMessages.Any())
                return delivery;

            delivery.PositionHistory = new List<Zuehlke.Camp2013.ConnectedVehicles.Position>();
            delivery.StatusHistory = new List<DeliveryStatus>();

            delivery.Vehicle = new Vehicle 
            {
                VehicleId = groupedMessages.First().VehicleId,
                SensorHistory = new List<SensorData>()
            };

            foreach(var message in groupedMessages)
            {
                delivery.PositionHistory.Add(message.MapToPosition());

                if(message.Type == MessageType.STATUS)
                    delivery.StatusHistory.Add(message.MapToDeliveryStatus());

                if (message.Type == MessageType.SENSOR)
                    delivery.Vehicle.SensorHistory.Add(message.MapToSensorData());
            }

            return delivery;
        }

        private static Zuehlke.Camp2013.ConnectedVehicles.Position MapToPosition(this Message message)
        {
            return new Zuehlke.Camp2013.ConnectedVehicles.Position
            {
                Timestamp = message.Timestamp,
                Geolocation = message.Position.MapToGeolocation()
            };
        }

        private static DeliveryStatus MapToDeliveryStatus(this Message message)
        {
            DeliveryStatusType statusType;
            var isDeliveryStatusKnown = Enum.TryParse<DeliveryStatusType>(message.Info, out statusType);

            return new DeliveryStatus
            {
                Timestamp = message.Timestamp,
                StatusType = isDeliveryStatusKnown ? statusType : DeliveryStatusType.OTHER,
                FallbackStatusInfo = isDeliveryStatusKnown ? null: message.Info
            };
        }

        private static SensorData MapToSensorData(this Message message)
        {
            return new SensorData
            {
                Timestamp = message.Timestamp,
                Speed = message.Speed,
                EngineTemperature = message.Temperature,
                FuelLeft = message.Fuel,
                OdoMeter = message.Kilometer,
                TirePressure = message.Pressure
            };
        }

        private static Geolocation MapToGeolocation(this Position position)
        {
            return new Geolocation
             {
                 Latitude = position.Latitude,
                 Longitude = position.Longitude
             };
        }
    }
}
