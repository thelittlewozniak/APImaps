using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APImaps.deserialiseDataApi;
using Newtonsoft.Json;

namespace APImaps
{
    class GetDataApi
    {
        private string origin;
        private List<string> waypoints;
        private double distance;
        private double time;
        public List<string> Waypoints { get=>waypoints; }
        public double DistanceGet { get=>distance; set=>distance=value; }
        public double TimeGet { get=>time; set=>time=value; }

        public GetDataApi()
        {
            waypoints = new List<string>();
            origin = null;
        }
        private void AddOrigin(string neworigin) => origin=neworigin;
        public void AddWaypoints(string newwaypoint)
        {
            if(waypoints.Count<=1)
            {
                AddOrigin(newwaypoint);
            }
            else
            {
                waypoints.Add(newwaypoint);
            }
        } 
        private string CreateString()
        {
             return string.Concat("https://maps.googleapis.com/maps/api/directions/json?&origin=" + origin + string.Join("&waypoints=", waypoints) + "$destination=" + waypoints[waypoints.Count - 1] + "&mode=DRIVING&" + "&key=AIzaSyCeF5hSrF5Rll25V1u0RWO6CFzmmQYDiQo");
        }
        private DataAPI CallAPI()
        {
            var json = new WebClient().DownloadString(CreateString());
            return JsonConvert.DeserializeObject<DataAPI>(json);
        }
        public void GetResponse(string rapidity)
        {
            switch (rapidity)
            {
                case "slow":
                    rapidity = "30";
                    break;
                case "normal":
                    rapidity = "10";
                    break;
                case "fast":
                    rapidity ="0";
                    break;

            }
            DataAPI data = CallAPI();
            foreach(RouteDes route in data.routes)
            {
                foreach(Leg step in route.legs)
                {
                    time += step.duration.value+Convert.ToInt32(rapidity);
                    distance += step.distance.value;
                }
            }
            time = time / 60;
            distance = distance / 1000;
        }
    }
}
