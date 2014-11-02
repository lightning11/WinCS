using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessObject.ConnectBase
{
    interface IDaoConnector
    {
        // DBを開く
        void DBOpen();

        // DBを閉じる
        void DBClose();

        // トランザクション開始
        void beginTrans();

        // トランザクションコミット
        void commit();

        // トランザクションロールバック
        void rollback();

        // データを取得
        DataTable dataFill(string strSQL);
        DataTable dataFill(string strSQL, List<DaoParameter> sqlParams);

    }
}
