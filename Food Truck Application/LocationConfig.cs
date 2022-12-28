using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device.Location;


namespace Food_Truck_Application
{
    public class LocationConfig
    {
        public double Latitude
        {
            get;
            set;
        }

        public double Longitude
        {
            get;
            set;
        }

        public string HumanAddress
        {
            get;
            set;
        }

        public GeoCoordinate GetCoord()
        {
            return new GeoCoordinate(Latitude, Longitude);
        }
    }
}