using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Admin
    {
        List<Driver> drivers;
        //CONSTRUCTORS
        public Admin()
        {
            drivers = new List<Driver>();
        }

        public void AddDriver(string name, int age, string gender, string address, string vType, string vModel, string vLicensePlate)
        {
            Driver driver = new Driver
            {
                Name = name,
                Age = age,
                Gender = gender,
                Address = address,
                Vehicle = new Vehicle
                {
                    Type = vType,
                    Model = vModel,
                    LicensePlate = vLicensePlate
                }
            };

            if (drivers.Count == 0)
            {
                driver.ID = 1;
            }
            else
            {
                driver.ID = drivers.Max(d => d.ID) + 1;
            }

            drivers.Add(driver);
            int n = drivers.Count;
            for (int i = 0; i < n; i++)
            {

                displayDriver(drivers[i]);
            }
        }
        //GETTER FUNCTION
        public List<Driver> driverList
        {
            get
            {
                return drivers;
            }
        }
        //FUNCTIONS
        public void UpdateDriverCurrentLocation(int id, string currentLocation)
        {
            foreach (Driver driver in drivers)
            {
                if (driver.ID == id)
                {
                    driver.updateLocation(currentLocation);
                    break; // Assuming driver IDs are unique, so we can exit loop after updating.
                }
            }
        }

        public void RemoveDriver(int id)
        {
            int n = drivers.Count;
            Driver driverToRemove = drivers.Find(driver => driver.ID == id);
            if (driverToRemove != null)
            {
                drivers.Remove(driverToRemove);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("THE DRIVER WITH " + id + " IS SUCCESSFULLY REMOVED");
                Console.ResetColor();
            }
            for (int i = 0; i < n; i++)
            {
               
                displayDriver(drivers[i]);
            }
        }


        public void updateDriver(int id)
        {
            int c = drivers.Count;
            for (int i = 0; i < c; i++)
            {
                if (drivers[i].ID == id)
                {
                    Console.WriteLine("------------Driver with ID " + id + " exists------------");
                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    if (name != string.Empty)
                    {
                        drivers[i].Name = name;
                    }
                    Console.Write("Enter Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string age = Console.ReadLine();
                    Console.ResetColor();
                    if (age != string.Empty)
                    {
                        int driverAge = Convert.ToInt32(age);
                        drivers[i].Age = driverAge;
                    }
                    Console.Write("Enter Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string gender = Console.ReadLine();
                    Console.ResetColor();
                    if (gender != null)
                    {
                        drivers[i].Gender = gender;
                    }
                    Console.Write("Enter Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    Console.ResetColor();
                    if (address != string.Empty)
                    {
                        drivers[i].Address = address;
                    }
                    Console.Write("Enter Vehicle Type (Car/Bike/Rickshaw): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleType = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleType != string.Empty)
                    {
                        drivers[i].Vehicle.Type = vehicleType;
                    }
                    Console.Write("Enter Vehicle Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleModel = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleModel != string.Empty)
                    {
                        drivers[i].Vehicle.Model = vehicleModel;
                    }
                    Console.Write("Enter Vehicle License Plate: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleLP = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleLP != string.Empty)
                    {
                        drivers[i].Vehicle.LicensePlate = vehicleLP;
                    }
                }
            }

        }
        public void UpdateAvailability(int id, bool val)
        {
            Driver driverToUpdate = drivers.Find(driver => driver.ID == id);
            if (driverToUpdate != null)
            {
                driverToUpdate.updateAvailability(val);
            }

        }


        public void displayDriver(Driver driver)
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Name           Age       Gender       V.Type        V.Model        V.License");
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine(driver.Name + "           " + driver.Age + "            " + driver.Gender + "           " + driver.Vehicle.Type + "            " + driver.Vehicle.Model + "            " + driver.Vehicle.LicensePlate);
            Console.WriteLine("----------------------------------------------------------------------------");
        }
      
        public void searchDriver()
        {
            int n = drivers.Count;
            int byID = -1;
            int[] byName = new int[n];
            int[] byAge = new int[n];
            int[] byGender = new int[n];
            int[] byAddress = new int[n];
            int[] byVehicleType = new int[n];
            int[] byVehicleModel = new int[n];
            int[] byVehicleLP = new int[n];
            Console.WriteLine("\n\n---------------------------------------------------------------");
            Console.WriteLine("Search options:");
            Console.WriteLine("1. By ID Search");
            Console.WriteLine("2. By Name Search");
            Console.WriteLine("3. By Age Search");
            Console.WriteLine("4. By Gender Search");
            Console.WriteLine("5. By Address Search");
            Console.WriteLine("6. By Vehicle Type Search");
            Console.WriteLine("7. By vehicle Model Search");
            Console.WriteLine("8. By vehicle License Plate Search");
            Console.WriteLine("---------------------------------------------------------------\n\n");
            int option;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter a number between 1 and 8:");
            Console.ResetColor();
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.Write("Enter Driver ID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string id = Console.ReadLine();
                    Console.ResetColor();
                    if (id != string.Empty)
                    {
                        int ID = Convert.ToInt32(id);
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].ID == ID)
                            {
                                byID = i;
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Results by ID");
                    Console.ResetColor();
                    if (byID != -1)
                        displayDriver(drivers[byID]);
                    break;
                case 2:
                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    if (name != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Name == name)
                            {
                                byName[i] = 1;
                            }
                        }
                    }
                    if (byName.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Name");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byName[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 3:
                    Console.Write("Enter Age: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string age = Console.ReadLine();
                    Console.ResetColor();
                    if (age != string.Empty)
                    {
                        int ageID = Convert.ToInt32(age);
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Age == ageID)
                            {
                                byAge[i] = 1;
                            }
                        }
                    }
                    if (byAge.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Age");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byAge[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 4:
                    Console.Write("Enter Gender: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string gender = Console.ReadLine();
                    Console.ResetColor();
                    if (gender != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Gender == gender)
                            {
                                byGender[i] = 1;
                            }
                        }
                    }
                    if (byGender.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Gender");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byGender[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 5:
                    Console.Write("Enter Address: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string address = Console.ReadLine();
                    Console.ResetColor();
                    if (address != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Address == address)
                            {
                                byAddress[i] = 1;
                            }
                        }
                    }
                    if (byAddress.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Address");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byAddress[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 6:
                    Console.Write("Enter Vehicle Type (Car/Bike/Rickshaw): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleType = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleType != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Vehicle.Type == vehicleType)
                            {
                                byVehicleType[i] = 1;
                            }
                        }
                    }
                    if (byVehicleType.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Vehicle Type");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byVehicleType[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 7:
                    Console.Write("Enter Vehicle Model: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleModel = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleModel != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Vehicle.Model == vehicleModel)
                            {
                                byVehicleModel[i] = 1;
                            }
                        }
                    }
                    if (byVehicleModel.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Vehicle Model");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byVehicleModel[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                case 8:
                    Console.Write("Enter Vehicle License Plate: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string vehicleLP = Console.ReadLine();
                    Console.ResetColor();
                    if (vehicleLP != string.Empty)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (drivers[i].Vehicle.LicensePlate == vehicleLP)
                            {
                                byVehicleLP[i] = 1;
                            }
                        }
                    }
                    if (byVehicleLP.Length > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Results by Vehicle License Plate");
                        Console.ResetColor();
                        for (int i = 0; i < n; i++)
                        {
                            if (byVehicleLP[i] == 1)
                                displayDriver(drivers[i]);
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
        }


        public bool SearchDriverByID(int id)
        {
            foreach (var driver in drivers)
            {
                if (driver.ID == id)
                {
                    return true;
                }
            }
            return false;
        }


    }
}