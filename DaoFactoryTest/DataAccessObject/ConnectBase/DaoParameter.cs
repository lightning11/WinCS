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
        // パラメータ名（バインド変数名）
        public string paramName { get; set; }
        // パラメータ型
        public DaoParameterDataType paramType { get; set; }
        // パラメータ値
        public object paramValue { get; set; }
    }
}
