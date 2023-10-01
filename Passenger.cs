using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Passenger
    {
        string name;
        string phone_No;
        //Ride ride = new Ride();
        //Vehicle vehicle = new Vehicle();
        //CONSTRUCTORs
        public Passenger()
        {
            name = string.Empty;
            phone_No = string.Empty;
        }
        public Passenger(string p_name, string phnNo)
        {
            name = p_name;
            phone_No = phnNo;
        }
        //GETTER AND SETTER
        public string Name
        {
            get
            {
                return name; 
            }
            set 
            { 
                name = value; 
            }
        }

        public string PhoneNo
        {
            get 
            { 
                return phone_No;
            }
            set 
            { 
                phone_No = value; 
            }
        }
        public int giveRating(int rate)
        {
            if (rate >= 1 && rate <= 5)
            {
                return rate;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Please give rating between 1 to 5.");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                string r = Console.ReadLine();
                Console.ResetColor();
                int rating = Convert.ToInt32(r);
                return -1;
            }

        }
        /*public void addRide(string Name, string phnNo, string startLocation, string endLocation, string TypeOfRide)
        {

            name = Name;
            phone_No = phnNo;
            ride.StartLocation.setLocation(startLocation);
            ride.EndLocation.setLocation(endLocation);
            vehicle.Type = TypeOfRide;
        }*/
      
    }
}