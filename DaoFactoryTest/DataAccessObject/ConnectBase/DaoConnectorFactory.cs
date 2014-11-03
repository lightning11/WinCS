using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccessObject.ConnectBase
{
    class DaoConnectorFactory
    {
        public IDaoConnector create()
        {

            string conString = ConfigurationManager.AppSettings["MySQLConnectionString"];

            IDaoConnector dao = new MySQLConnector(conString);

            return dao;
        }

    }
}
