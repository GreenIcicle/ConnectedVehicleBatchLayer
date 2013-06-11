namespace csharp Zuehlke.ConnectedVehicles

typedef i64 Timestamp

enum VehicleType {
	CAR,
	VAN,
	BIKE
}

enum DeliveryStatusType {
	START,
	DRIVING,
	REFUELLING,
	STOP,
	UNLOADING,
	REPAIRING,
	OTHER
}

struct Vehicle {
	1: required string vehicleId,
	2: required VehicleType vehicleType,
	3: optional string vehicleModel,
	4: optional string driver
}

struct DeliveryStatus {
	1: required Timestamp timestamp,
	2: required DeliveryStatusType statusType,
	3: optional string additionalStatusInfo
}

struct Delivery {
	1: required Vehicle vehicle,
	2: required list<DeliveryStatus> statusHistory 
}


