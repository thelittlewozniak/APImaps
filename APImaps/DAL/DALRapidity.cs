using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    class DALRapidity
    {
        private Model1 model;
        public DALRapidity()
        {
            model = Model1.Instance;
        }
        public Rapidity GetRapidity(int idrapidity)
        {
            Rapidity rapidity=(Rapidity)(from Rapidity r in model.rapidities where r.idrapidity == idrapidity select r).First();
            return rapidity;
        }
        public List<Rapidity> GetRapidities()
        {
            return model.rapidities.ToList();
        }

    }
}
