using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.ConnectBase
{
    class DaoConnectorFactory
    {
        public IDaoConnector create()
        {
            IDaoConnector dao = new MySQLConnector();

            return dao;
        }

    }
}
