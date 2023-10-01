using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_MYRID
{
    internal class Location
    {
        float latitude;
        float longitude;
        
        //FUNCTIONS-GETTER AND SETTER
        public float getLatitude()
        {
            return latitude;
        }
        public float getLongitude()
        {
            return longitude;
        }
        public void setLocation(float longitude, float latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }
        public void setLocation(string location)
        {
            string[] coordinates = location.Split(',');
            if (coordinates.Length == 2 && float.TryParse(coordinates[0], out float lat) && float.TryParse(coordinates[1], out float lon))
            {
                latitude = lat;
                longitude = lon;
            }
            else
            {
                throw new ArgumentException("Invalid location format. Please provide latitude and longitude separated by a comma.");
            }
        }



    }
}