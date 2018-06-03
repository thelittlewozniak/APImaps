﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    class DALRoute
    {
        private Model1 model;
        public DALRoute()
        {
            model =Model1.Instance;
        }
        public void AddRoute(Route newroute)
        {
            model.routes.Add(newroute);
            model.SaveChanges();
        }
        public List<Route> GetRoutes()
        {
            return model.routes.ToList();
        }
        public Route GetRoute(int idUser)
        {
            Route route = (Route)(from Route e in model.routes where e.idplayer == idUser select e);

            return route;
        }
        public void ChangeStatus(Status Newstatus,Route route)
        {
            Route editroute = (Route)(from Route e in model.routes where e.idroute == route.idroute select e);
            editroute.status = Newstatus;
            model.SaveChanges();
        }
        public Route Calculate(GetDataApi api,Player player)
        {
            Route newroute = new Route();
            api.GetResponse(player.rapidity.RapidityName);
            newroute.wazelink = CreateWazeLink(api.Waypoints);
            newroute.mapslink = CreateMapsLink(api.Waypoints);
            newroute.time = api.TimeGet;
            newroute.status=

            return newroute;
        }
        private static string CreateWazeLink(List<string> listLatLong)
        {
            string wazelink = "";
            foreach (string latlong in listLatLong)
            {
                wazelink += ("waze://?ll=" + latlong + "&navigate=yes");
            }

            return wazelink;
        }
        private static string CreateMapsLink(List<string> listLatLong)
        {
            return "https://www.google.com/maps/dir/" + string.Join("/", listLatLong);
        }

    }
}