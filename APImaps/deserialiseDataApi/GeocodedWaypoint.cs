using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.deserialiseDataApi
{
    class GeocodedWaypoint
    {
        public string geocoder_status;
        public string place_id;
        public List<string> types;
        public GeocodedWaypoint(string geocoder_status,string place_id, List<string> types)
        {
            this.geocoder_status = geocoder_status;
            this.place_id = place_id;
            this.types = types;
        }
    }
}
