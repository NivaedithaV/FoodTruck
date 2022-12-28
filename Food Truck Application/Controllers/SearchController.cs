using Food_Truck_Application.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Food_Truck_Application.Controllers
{
    /// <summary>
    /// Controller class that facilitates the search process of a food truck
    /// </summary>
    public class SearchController
    {
        /// <summary>
        /// Gets List of food trucks based on the search criteria. 
        /// </summary>
        /// <param name="applicantName">Search a truck based on applicants name.</param>
        /// <param name="address">Search a truck based on address.</param>
        /// <param name="status">To set a status filter for searching a truck.</param>
        /// <param name="latitude">Search a truck based on latitude.<param>
        /// <param name="longitude">Search a truck based on latitude.</param>
        /// <returns></returns>
        [HttpGet]
        public List<FoodTruckConfig> Get(string applicantName = null,
            string address = null, string status = null, double latitude = 0, double longitude = 0)
        {
            try
            {
                if (SysExtensions.IsNullOrEmpty(applicantName) && SysExtensions.IsNullOrEmpty(address)
                    && (SysExtensions.IsNullOrEmpty(latitude.ToString()) || SysExtensions.IsNullOrEmpty(longitude.ToString())))
                    return null;

                var foodTrucks = new List<FoodTruckConfig>();

                var helper = new SearchHelper();

                if (!SysExtensions.IsNullOrEmpty(applicantName))
                    foodTrucks.AddRange(helper.GetByApplicant(applicantName, status));
                else if (!SysExtensions.IsNullOrEmpty(address))
                    foodTrucks.AddRange(helper.GetByAddress(address));
                else if (!SysExtensions.IsNullOrEmpty(latitude.ToString())
                    && !SysExtensions.IsNullOrEmpty(longitude.ToString()))
                    foodTrucks.AddRange(helper.GetByLatLong(latitude, longitude, status));

                return foodTrucks;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}