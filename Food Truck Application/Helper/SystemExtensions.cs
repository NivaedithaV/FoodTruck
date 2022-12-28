using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food_Truck_Application.Helper
{
    /// <summary>
    /// Contains extension methods for system methods.
    /// </summary>
    public static class SysExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return value == null || value.Trim().Length == 0;
        }
    }
}