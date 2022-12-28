using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Food_Truck_Application
{
    public static class FoodTruckDL
    {
        private static String API_URL = "http://data.sfgov.org/resource/rqzj-sfat.json";

        public static List<FoodTruckConfig> getData()
        {
            try
            {
                var response = new WebClient().DownloadString(API_URL);
                if (response != null)
                    return JsonConvert.DeserializeObject<List<FoodTruckConfig>>(response);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }


}