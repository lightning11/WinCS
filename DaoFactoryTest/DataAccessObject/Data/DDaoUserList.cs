using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.ConnectBase;

namespace DataAccessObject.Data
{
    public class DDaoUserList : DDaoBase
    {
        public object userId { get; set; }
        public object account { get; set; }
        public object password { get; set; }
        public object displayName { get; set; }
    }
}
