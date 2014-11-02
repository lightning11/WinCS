using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject.ConnectBase
{
    public enum DaoParameterDataType
    {
      typeString,
      typeDate,
      typeDecimal
   }

    public class DaoParameter
    {
        public string paramName { get; set; }
        public DaoParameterDataType paramType { get; set; }
        public object paramValue { get; set; }
    }
}
