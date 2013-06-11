namespace csharp Zuehlke.ConnectedVehicles

enum VehicleType {
	CAR,
	VAN,
	BIKE
}

struct Vehicle {
	1: required string vehicleId,
	2: required VehicleType vehicleType,
	3: optional string vehicleModel,
	4: optional string driver
}


