using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    interface IRoute
    {
        void AddRoute(Route newroute);
        List<Route> GetRoutes();
        Route GetRoute(int idUser);
        void ChangeStatus(Status Newstatus, Route route);
        Route Calculate(GetDataApi api, Player player);
        void DeleteRoute(Route route);
    }
}
