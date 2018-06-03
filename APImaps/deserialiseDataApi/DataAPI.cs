using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.deserialiseDataApi
{
    class DataAPI
    {
        public List<GeocodedWaypoint> geocoded_waypoints;
        public List<RouteDes> routes;
        public string status;
    }
}
