using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    class DALTrust:ITrust
    {
        private Model1 model;
        public DALTrust()
        {
            model = Model1.Instance;
        }
        public Trust GetTrust(int idtrust)
        {
            return (from Trust t in model.trusts where t.idtrust == idtrust select t).First();
        }

    }
}
