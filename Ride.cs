using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    enum TypeOfRide { Bike, Rickshaw, Car };
    internal class Ride : Vehicle
    {
        Location start_location;
        Location end_location;
        int price;
        Driver driver;
        Passenger passenger;
        float fuel_price = 370;

        //CONSTRUCTORS
        public Ride() : base()
        {
            start_location = new Location();
            end_location = new Location();
            driver = new Driver();
            passenger = new Passenger();
        }


        //GETTER AND SETTER FUNCTIONS
        public Location StartLocation
        {
            get 
            { 
                return start_location; 
            }
        }
        public Location EndLocation
        {
            get 
            {
                return end_location; 
            }
            
        }
        public int Price
        {
            get 
            { 
                return price; 
            }
            set 
            { 
                price = value;
            }
        }
        public Driver Driver
        {
            get 
            { 
                return driver; 
            }
            
        }
        public Passenger Passenger
        {
            get 
            { 
                return passenger; 
            }
        }
        public float FuelPrice
        {
            get 
            { 
                return fuel_price;
            }
        }
        //BASE CLASS GETTER AND SETTER
        public override string Type
        {
            get => base.Type;
            set => base.Type = value;
        }
        public void assignPassenger(Passenger passenger)
        { 
            this.passenger = passenger;
        }
        public int AssignDriver(string startLocation, List<Driver> drivers)
        {
            int indexOfNearestDriver = -1;
            float shortestDistance = float.MaxValue;

            foreach (var driver in drivers)
            {
                if (driver.getAvailability())
                {
                    float distance = calculateDistance(driver.CurrentLocation, startLocation);
                    if (distance < shortestDistance)
                    {
                        shortestDistance = distance;
                        indexOfNearestDriver = drivers.IndexOf(driver);
                    }
                }
            }

            return indexOfNearestDriver;
        }

        public int CalculatePrice()
        {
            float distance = calculateDistance();
            float fuelEfficiency;
            float commissionPercentage;

            if (Type.Equals("Car", StringComparison.OrdinalIgnoreCase))
            {
                fuelEfficiency = 15;
                commissionPercentage = 0.2f;
            }
            else if (Type.Equals("Bike", StringComparison.OrdinalIgnoreCase))
            {
                fuelEfficiency = 50;
                commissionPercentage = 0.05f;
            }
            else if (Type.Equals("Rickshaw", StringComparison.OrdinalIgnoreCase))
            {
                fuelEfficiency = 35;
                commissionPercentage = 0.1f;
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type");
            }

            int basePrice = (int)((distance * fuel_price) / fuelEfficiency);
            float commission = basePrice * commissionPercentage;
            int totalPrice = (int)(basePrice + commission);

            return totalPrice;
        }


        public void setLocations(string startlocation, string endlocation)
        {
            start_location.setLocation(startlocation);
            end_location.setLocation(endlocation);
        }

        float calculateDistance()
        {
            float lat1 = start_location.getLatitude();
            float lon1 = start_location.getLongitude();

            float lat2 = end_location.getLatitude();
            float lon2 = end_location.getLongitude();

            float deltaLat = lat2 - lat1;
            float deltaLon = lon2 - lon1;

            float squaredDistance = deltaLat * deltaLat + deltaLon * deltaLon;

            float distance = (float)Math.Sqrt(squaredDistance);
            return distance;
        }

        float calculateDistance(Location destinationLocation, string startLocation)
        {
            float lat1 = destinationLocation.getLatitude();
            float lon1 = destinationLocation.getLongitude();

            Location startLocOriginal = new Location();
            startLocOriginal.setLocation(startLocation);
            float lat2 = startLocOriginal.getLatitude();
            float lon2 = startLocOriginal.getLongitude();

            float deltaLat = lat2 - lat1;
            float deltaLon = lon2 - lon1;

            float squaredDistance = deltaLat * deltaLat + deltaLon * deltaLon;

            float distance = (float)Math.Sqrt(squaredDistance);
            return distance;
        }
        public void addRide(string name, string phnNo, string startLocation, string endLocation, string TypeOfRide)
        {

            passenger.Name = name;
            passenger.PhoneNo = phnNo;
            start_location.setLocation(startLocation);
            end_location.setLocation(endLocation);
            Type = TypeOfRide;
        }

    }
}