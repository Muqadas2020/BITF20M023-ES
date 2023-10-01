using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Driver
    {
        int id;
        string name;
        int age;
        string gender;
        string address;
        string phone_No;
        Location curr_location;
        Vehicle vehicle;
        List<int> rating;
        bool availability;
        //CONSTRUCTOR
        public Driver()
        {
            name = string.Empty;
            age = 0;
            gender = string.Empty;
            address = string.Empty;
            phone_No = string.Empty;
            vehicle = new Vehicle();
            rating = new List<int>();
            availability = false;
            curr_location = new Location();
            id = 10;
        }
        //GETTER AND SETTER FUNCTIONS
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
        public int Age
        {
            get 
            { 
                return age;
            }
            set 
            { age = value; 
            }
        }
        public string Gender
        {
            get 
            { 
                return gender; 
            }
            set 
            { 
                gender = value; 
            }
        }
        public string Address
        {
            get
            { 
                return address; 
            }
            set 
            { 
                address = value; 
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
        public Location CurrentLocation
        {
            get 
            { 
                return curr_location;
            }
            set 
            { 
                curr_location = value; 
            }
        }
        public Vehicle Vehicle
        {
            get
            { 
                return vehicle; 
            }
            set
            { 
                vehicle = value; 
            }

        }
        public bool getAvailability() 
        { 
            return availability; 
        }
        public int ID
        {
            get 
            { 
                return id; 
            }
            set 
            { 
                id = value; 
            }
        }

        public void updateAvailability(bool val)
        {
            this.availability = val;
        }
        public void setRating(int rate)
        {
            rating.Add(rate);
        }
        public int GetRating()
        {
            int totalRatings = 0;
            int numberOfRatings = rating.Count;

            foreach (int r in rating)
            {
                totalRatings += r;
            }

            int averageRating = numberOfRatings > 0 ? totalRatings / numberOfRatings : 0;
            return averageRating;
        }

        public void updateLocation(Location loc)
        {
            curr_location = loc;
        }
        public void updateLocation(string loc)
        {
            curr_location.setLocation(loc);
        }
    }
}