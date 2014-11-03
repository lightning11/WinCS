using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessObject.ConnectBase;
using System.Data;
using DataAccessObject.Data;

namespace DataAccessObject.Dao
{
    public class DaoUserList : DaoBase
    {

        private string strSelect = "Select * From UserList Where UserId = ?userId";

        private string strInsert = "Insert Into UserList (UserId, Account, Password, DisplayName) value (?userId, ?account, ?password, ?displayName)";

        // ----------------------------------------------------
        // 検索処理
        // ----------------------------------------------------
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

        // ----------------------------------------------------
        // 追加処理
        // ----------------------------------------------------
        public int insertUserList(DDaoUserList insData)
        {

            // トランザクション開始
            beginTrans();

            List<DaoParameter> paramList = new List<DaoParameter>();

            DaoParameter user = new DaoParameter();
            user.paramName = "?userId";
            user.paramType = DaoParameterDataType.typeDecimal;
            user.paramValue = insData.userId;
            paramList.Add(user);

            user = new DaoParameter();
            user.paramName = "?account";
            user.paramType = DaoParameterDataType.typeString;
            user.paramValue = insData.account;
            paramList.Add(user);

            user = new DaoParameter();
            user.paramName = "?password";
            user.paramType = DaoParameterDataType.typeString;
            user.paramValue = insData.password;
            paramList.Add(user);

            user = new DaoParameter();
            user.paramName = "?displayName";
            user.paramType = DaoParameterDataType.typeString;
            user.paramValue = insData.displayName;
            paramList.Add(user);

            // データ検索実行
            int cnt = executeQuery(strInsert, paramList);

            // コミット
            commit();

            return cnt;
        }



    }
}
