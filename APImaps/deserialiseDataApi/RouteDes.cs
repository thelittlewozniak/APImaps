using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.deserialiseDataApi
{
    class RouteDes
    {
        public Bound bounds;
        public string copyrights;
        public List<Leg> legs;
        public Polyline overview_polyline;
        public string summary;
        public List<string> warnings;
        public List<int> waypoint_order;
    }
}
