using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Vehicle
    {
        string type;
        string model;
        string license_plate;

        //DEFAULT CONSTRUCTOR
        public Vehicle()
        {
            type = "";
            model = "";
            license_plate = "";
        }
        //CONSTRUCTOR
        public Vehicle(string type, string model, string licensePlate)
        {
            Type = type;
            Model = model;
            license_plate = licensePlate;
        }


       //GETTER AND SETTER FUNCTIONS/METHODS
        public virtual string Type
        {
            get
            { 
                return type; 
            }
            set 
            { 
                type = value; 
            }
        }

        public string Model
        {
            get 
            { 
                return model; 
            }
            set 
            { 
                model = value; 
            }
        }

        public string LicensePlate
        {
            get 
            { 
                return license_plate; 
            }
            set
            { 
                license_plate = value; 
            }
        }
    }
}