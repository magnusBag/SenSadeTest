CREATE TABLE "ParkingSpace" (
  "Id" SERIAL PRIMARY KEY,
  "Status" boolean,
  "BoothNumber" int,
  "ParkingLot_id" int
);

CREATE TABLE "ParkingLot" (
  "Id" SERIAL PRIMARY KEY,
  "RoadName" varchar,
  "City" varchar,
  "ZipCode" varchar,
  "Latitude" float,
  "Longitude" float
);

ALTER TABLE "ParkingLot" ADD FOREIGN KEY ("Id") REFERENCES "ParkingSpace" ("ParkingLot_id");
