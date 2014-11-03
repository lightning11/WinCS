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
        #region "データベース基本処理"

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

        #endregion

        #region "データベース操作処理"

        // データを取得
        DataTable dataFill(string strSQL);
        DataTable dataFill(string strSQL, List<DaoParameter> sqlParams);

        // クエリーを実行
        int executeQuery(string strSQL);
        int executeQuery(string strSQL, List<DaoParameter> sqlParams);

        #endregion

    }
}
