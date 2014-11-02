using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.ConnectBase;
using System.Data;

namespace DataAccessObject.Dao
{
    public class DaoUserList : DaoBase
    {

        private string strSelect = "Select * From UserList Where UserId = ?userId";


        public DataTable selectAllUserList()
        {
            // トランザクション開始
            beginTrans();

            List<DaoParameter> paramList = new List<DaoParameter>();

            DaoParameter user = new DaoParameter();

            user.paramName = "?userId";
            user.paramType = DaoParameterDataType.typeDecimal;
            user.paramValue = new decimal(1);

            paramList.Add(user);

            // データ検索実行
            DataTable list = dataFill(strSelect, paramList);

            // コミット
            commit();

            return list;
        }

    }
}
