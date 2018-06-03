using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    interface IRapidity
    {
        Rapidity GetRapidity(int idrapidity);
        List<Rapidity> GetRapidities();
    }
}
