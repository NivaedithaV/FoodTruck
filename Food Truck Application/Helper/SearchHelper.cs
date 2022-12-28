using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Device;
using System.Device.Location;

namespace Food_Truck_Application.Helper
{
    /// <summary>
    /// Consists of helper methods that facilitates the search process.
    /// </summary>
    public class SearchHelper
    {

        private List<FoodTruckConfig> Data;

        public SearchHelper()
        {
            this.Data = FoodTruckDL.getData();

        }

        /// <summary>
        /// Gets list of food trucks by applicants name.
        /// </summary>
        /// <param name="applicantName"> Name of the applicant for whom the search is done.</param>
        /// <param name="status">Status of the food truck.</param>
        /// <returns></returns>
        public List<FoodTruckConfig> GetByApplicant(string applicantName, string status)
        {
            return !SysExtensions.IsNullOrEmpty(status) ? this.Data.FindAll(c => c.Applicant.Replace(" ", "").ToLower() == applicantName.Replace(" ", "").ToLower()
                                      && c.Status.Equals(status))
                                      : this.Data.FindAll(c => c.Applicant.Replace(" ", "").ToLower() == applicantName.Replace(" ", "").ToLower());
        }

        /// <summary>
        /// Gets list of food trucks based on the address typed.
        /// </summary>
        /// <param name="address">Address which is searched for.</param>
        /// <returns></returns>
        public List<FoodTruckConfig> GetByAddress(string address)
        {

            return this.Data.FindAll(c => c.Address.ToLower().Contains(address.ToLower()));
        }

        /// <summary>
        /// Gets list of food trucks based on latitude and longitude.
        /// </summary>
        /// <param name="latitude">Latitude to search the food truck</param>
        /// <param name="longitude">Longitude to search the food truck</param>
        /// <param name="status">Status of the food truck to be searched</param>
        /// <returns></returns>
        public List<FoodTruckConfig> GetByLatLong(Double latitude, Double longitude, string status)
        {
            var foodTrucks = new List<FoodTruckConfig>();
            status = SysExtensions.IsNullOrEmpty(status) ? "approved" : status;
            var closestTrucks = this.Data.Where(d => d.Status.ToLower() == status.ToLower())
                                   .Select(x => new GeoCoordinate(x.Latitude, x.Longitude))
                                   .OrderBy(x => x.GetDistanceTo(new GeoCoordinate(latitude, longitude)))
                                   .Take(5);

            foreach (var truck in closestTrucks)
                foodTrucks.Add(this.Data.FirstOrDefault(x => (x.Location.GetCoord() == truck)));

            return foodTrucks;
        }
    }
}