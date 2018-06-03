using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.deserialiseDataApi
{
    class Leg
    {
        public DistanceDuration distance;
        public DistanceDuration duration;
        public string end_adress;
        public Location end_location;
        public string start_adress;
        public Location start_location;
        public List<Step> steps;
        public List<string> traffic_speed_entry;
        public List<string> via_waypoint;
    }
}
