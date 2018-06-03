using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.deserialiseDataApi
{
    class Step
    {
        public DistanceDuration distance;
        public DistanceDuration duration;
        public Location end_loaction;
        public string html_instructions;
        public string maneuver;
        public Polyline polyline;
        public Location start_location;
        public string travel_mode;
    }
}
