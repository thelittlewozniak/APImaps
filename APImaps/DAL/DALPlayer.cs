using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    class DALPlayer
    {
        private Model1 model;
        public DALPlayer()
        {
            model = Model1.Instance;
        }
        public List<Player> GetPlayers()
        {
            return model.players.ToList();
        }
        public Player GetPlayer(int idPlayer)
        {
            Player player = (Player)(from Player p in model.players where p.idplayer == idPlayer select p).First();
            return player;
        }
        public Player GetPlayer(string username)
        {
            Player player = (Player)(from Player p in model.players where p.nickname == username select p).First();
            return player;
        }
        public void AddPlayer(Player p)
        {
            model.players.Add(p);
            model.SaveChanges();
        }
    }
}
