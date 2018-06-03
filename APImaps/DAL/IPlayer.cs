using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    interface IPlayer
    {
        List<Player> GetPlayers();
        Player GetPlayer(int idPlayer);
        Player GetPlayer(string username);
        void AddPlayer(Player p);
    }
}
