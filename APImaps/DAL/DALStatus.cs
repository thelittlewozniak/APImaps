using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APImaps.DAL
{
    class DALStatus:IStatus
    {
        private Model1 model;
        public DALStatus()
        {
            model = Model1.Instance;
        }
        public Status GetStatus(int idStatus)
        {
            return (from Status s in model.status where s.idstatus == idStatus select s).First();
        }
    }
}
