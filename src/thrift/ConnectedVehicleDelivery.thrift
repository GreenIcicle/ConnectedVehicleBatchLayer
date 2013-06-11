namespace csharp Zuehlke.ConnectedVehicles

// The schema uses timestamps a lot. The data is expressed
// in integer numbers. To get a semantically correct type name,
// we define an 64bit int as "TimeStamp".
//
// TimeStamp is in milliseconds. In the ConnectedVehicle sample data,
// there is not a defined start time, all timestamps for a vehicle 
// start at zero.
typedef i64 Timestamp

enum VehicleType {
	CAR,
	VAN,
	BIKE,
	OTHER		// Catchall for unexpected values
}

enum DeliveryStatusType {
	START,
	DRIVING,
	REFUELLING,
	STOP,
	UNLOADING,
	REPAIRING,
	OTHER		// Catchall for unexpected values
}

// A data point recorded by the vehicle's sensors.
//
// We thought about using an associative array for sensor
// names, but decided to use optional fields - this is more
// compact, otherwise we'd have to repeat the sensor names for each
// data point.
struct SensorData {
	1: required Timestamp timestamp,
	2: optional double speed,
	3: optional double fuelLeft,
	4: optional double odoMeter, // kilometers the vehicle has moved in total
	5: optional double engineTemperature,
	6: optional double tirePressure
}

// Describes a point in time when the status of a delivery changes - 
// for example, when the delivery starts and ends.
struct DeliveryStatus {
	1: required Timestamp timestamp,
	2: required DeliveryStatusType statusType,
	3: optional string additionalStatusInfo
}

// A geolocation. Duh.
struct Geolocation {
	1: required double latitude,
	2: required double longitude
}

// The position something is at at a given point in time.
struct Position {
	1: required Timestamp timestamp,
	2: required Geolocation geolocation
}

// Entity: the vehicle that runs the delivery.
//
// The sensor history belongs to the vehicle, as the sensors
// are mounted to the vehicle. 
struct Vehicle {
	1: required string vehicleId,
	2: required VehicleType vehicleType,
	3: optional string vehicleModel,	
	4: optional list<SensorData> sensorHistory
}

// Aggregate Root: a delivery run.
// A delivery is performed by a driver in a vehicle.
// The histories of statuses and positions are recorded.
struct Delivery {
	1: required Vehicle vehicle,
	2: required string driver,	
	3: optional list<DeliveryStatus> statusHistory,
	4: optional string origin,		// start point of the delivery (name of the place, no geolocation)
	5: optional string destination, // planned end point of the delivery (name of the place, no geolocation)
	6: optional string region,
	7: optional list<Position> positionHistory
}


