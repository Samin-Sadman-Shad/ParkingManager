using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagerApplication.Common.Utils
{
    public static class MathUtils
    {
        public static double EquirectangularDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double R = 6371; // km

            double lat1Rad = DegreesToRadians(lat1);
            double lon1Rad = DegreesToRadians(lon1);
            double lat2Rad = DegreesToRadians(lat2);
            double lon2Rad = DegreesToRadians(lon2);

            double x = (lon2Rad - lon1Rad) * Math.Cos((lat1Rad + lat2Rad) / 2);
            double y = lat2Rad - lat1Rad;

            double distance = R * Math.Sqrt(x * x + y * y);
            return distance;
        }

        private static double DegreesToRadians(double lat1)
        {
            return lat1 * Math.PI / 180.0;
        }
    }
}
