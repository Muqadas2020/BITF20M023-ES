using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Admin admin = new Admin();
            Passenger passenger = new Passenger();
            int option = 0;
            while (option != 4)
            {
                Console.WriteLine("Main Menu:");               
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("WELCOME TO MYRIDE");
                Console.WriteLine("----------------------------------------------------------------------------");
                Console.WriteLine("1. Book a Ride");
                Console.WriteLine("2. Enter as Driver");
                Console.WriteLine("3. Enter as Admin");
                Console.Write("\nPress 1 to 3 to select an option: ");
                Console.ForegroundColor = ConsoleColor.Green;
                option = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();
                Console.WriteLine("\n\n");
                while (option != 1 && option != 2 && option != 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Option!");
                    Console.ResetColor();
                    Console.Write("Please Press 1 to 3 to select an option: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    option = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    Console.WriteLine("\n\n");
                }
                //OPTION 1 - BOOK A RIDE
                if (option == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Book a Ride");
                    Console.ResetColor();
                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    Console.Write("Enter Phone no: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string phnNo = Console.ReadLine();
                    Console.ResetColor();
                    Console.Write("Enter Start Location: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string startLoc = Console.ReadLine();
                    Console.ResetColor();
                    Console.Write("Enter End Location: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string endLoc = Console.ReadLine();
                    Console.ResetColor();
                    Console.Write("Enter Ride Type (Car / Rickshaw / Bike): ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string rType = Console.ReadLine();
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("----------------------------THANK YOU-------------------------------");
                    Console.ResetColor();

                    Ride myRide = new Ride();
                    myRide.addRide(name, phnNo, startLoc, endLoc, rType);
                    
                    int totalprice = myRide.CalculatePrice();
                    Console.WriteLine("Price for this ride is: " + totalprice);

                    Console.Write("Enter ‘Y’ if you want to Book the ride, enter ‘N’ if you want to cancel operation: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string choice = Console.ReadLine();
                    Console.ResetColor();
                    if (choice == "Y" || choice == "y")
                    {
                        int id = myRide.AssignDriver(startLoc, admin.driverList);
                        if (id == -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry No Driver Available!");
                            Console.ResetColor();
                            Console.WriteLine("\n\n");
                        }
                        else
                        {
                            Console.WriteLine("\nHappy Travel...!");
                            Console.Write("\nGive rating out of 5: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string r = Console.ReadLine();
                            Console.ResetColor();
                            int rating = Convert.ToInt32(r);
                            int rate = passenger.giveRating(rating);
                            admin.driverList[id].setRating(rate);
                            Console.WriteLine("\n\n");
                        }
                    }

                }
                // OPTION 2 - ENTER AS DRIVER
                else if (option == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter as Driver");
                    Console.ResetColor();
                    Console.Write("Enter ID: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    Console.Write("Enter Name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string name = Console.ReadLine();
                    Console.ResetColor();
                    if (admin.SearchDriverByID(id) == true)
                    {
                        Console.WriteLine("Hello " + name + "!");
                        Console.Write("\nEnter your Current Location: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string location = Console.ReadLine();
                        Console.ResetColor();
                        admin.UpdateDriverCurrentLocation(id, location);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Location updated!");
                        Console.ResetColor();
                        Console.WriteLine("\n\n");
                        int driverOption = 0;
                        while (driverOption != 3)
                        {
                            Console.WriteLine("DRIVER OPTIONS:");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.WriteLine("1. Change Availability");
                            Console.WriteLine("2. Change Location");
                            Console.WriteLine("3. Exit as Driver");
                            Console.WriteLine("----------------------------------------------------------------------------");
                            Console.Write("Press 1 to 3 to select an option: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            driverOption = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();
                            Console.WriteLine("\n\n");
                            while (driverOption != 1 && driverOption != 2 && driverOption != 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid Option!");
                                Console.ResetColor();
                                Console.Write("Please Press 1 to 3 to select an option: ");
                                driverOption = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\n\n");
                            }
                            if (driverOption == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Availability Option");
                                Console.ResetColor();
                                Console.Write("Are you available (Y/N): ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                string availability = Console.ReadLine();
                                Console.ResetColor();
                                if (availability == "y" || availability == "Y")
                                {
                                    admin.UpdateAvailability(id, true);
                                    Console.WriteLine("\n\n");
                                }
                                else
                                    admin.UpdateAvailability(id, false);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Availability Updated!");
                                Console.ResetColor();
                                Console.WriteLine("\n\n");
                            }
                            else if (driverOption == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Change Location Option");
                                Console.ResetColor();
                                Console.Write("\nEnter your Location: ");
                                Console.ForegroundColor = ConsoleColor.Green;
                                location = Console.ReadLine();
                                Console.ResetColor();
                                admin.UpdateDriverCurrentLocation(id, location);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Location updated!");
                                Console.ResetColor();
                                Console.WriteLine("\n\n");
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Driver with ID " + id + " is not registered! Please Register yourself First");
                        Console.ResetColor();
                        Console.WriteLine("\n\n");
                    }
                }
                else if (option == 3)
                {
                    int AdminOption = 0;
                    while (AdminOption != 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Enter as Admin");
                        Console.ResetColor();
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.WriteLine("1. Add Driver");
                        Console.WriteLine("2. Remove Driver");
                        Console.WriteLine("3. Update Driver");
                        Console.WriteLine("4. Search Driver");
                        Console.WriteLine("5. Exit as Admin");
                        Console.WriteLine("----------------------------------------------------------------------------");
                        Console.Write("Press 1 to 5 to select an option: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        AdminOption = Convert.ToInt32(Console.ReadLine());
                        Console.ResetColor();

                        while (AdminOption != 1 && AdminOption != 2 && AdminOption != 3 && AdminOption != 4 && AdminOption != 5)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Option!");
                            Console.ResetColor();
                            Console.Write("Please Press 1 to 5 to select an option: ");
                            AdminOption = Convert.ToInt32(Console.ReadLine());
                        }
                        if (AdminOption == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Add a driver");
                            Console.ResetColor();
                            Console.Write("Enter Name: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string name = Console.ReadLine();
                            Console.ResetColor();
                            Console.Write("Enter Age: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string age = Console.ReadLine();
                            Console.ResetColor();
                            int driverAge = Convert.ToInt32(age);
                            Console.Write("Enter Gender: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string gender = Console.ReadLine();
                            Console.ResetColor();
                            Console.Write("Enter Address: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string address = Console.ReadLine();
                            Console.ResetColor();
                            Console.Write("Enter Vehicle Type (Car/Bike/Rickshaw): ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string vehicleType = Console.ReadLine();
                            Console.ResetColor();
                            Console.Write("Enter Vehicle Model: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string vehicleModel = Console.ReadLine();
                            Console.ResetColor();
                            Console.Write("Enter Vehicle License Plate: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string vehicleLP = Console.ReadLine();
                            Console.ResetColor();
                            admin.AddDriver(name, driverAge, gender, address, vehicleType, vehicleModel, vehicleLP);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.ResetColor();
                            Console.WriteLine("\n\n");
                        }
                        else if (AdminOption == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Remove a driver");
                            Console.ResetColor();
                            Console.WriteLine("Enter the Driver ID: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string ID = Console.ReadLine();
                            Console.ResetColor();
                            int id = Convert.ToInt32(ID);
                            admin.RemoveDriver(id);
                            Console.WriteLine("\n\n");
                        }
                        else if (AdminOption == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Update a driver");
                            Console.ResetColor();
                            Console.Write("Enter Driver ID: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            string id = Console.ReadLine();
                            Console.ResetColor();
                            int ID = Convert.ToInt32(id);
                            admin.updateDriver(ID);
                            Console.WriteLine("\n\n");
                        }
                        else if (AdminOption == 4)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Search a driver");
                            Console.ResetColor();
                            admin.searchDriver();
                            Console.WriteLine("\n\n");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!Please enter 1to 5:");
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("--------------------------THANK YOU FOR USING MYRIDE------------------------");
                    Console.ResetColor();
                }
            }
        }
    }
}