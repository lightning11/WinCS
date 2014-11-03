using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccessObject.ConnectBase
{
    class MySQLConnector : IDaoConnector
    {

        #region "定数・変数"

        // 接続文字列
        private string conString = null;

        // 接続情報
        private MySqlConnection conn = null;
        // トランザクション情報
        private MySqlTransaction trans = null;

        #endregion

        #region "コンストラクタ"

        // ----------------------------------------------------
        // コンストラクタ
        // ----------------------------------------------------
        public MySQLConnector(string connectionString)
        {
            conString = connectionString;
        }

        #endregion

        #region "データベース基本処理"

        // ----------------------------------------------------
        // DBを開く
        // ----------------------------------------------------
        public void DBOpen()
        {
            conn = new MySqlConnection(conString);
            if (conn != null)
            {
                conn.Open();
            }
        }

        // ----------------------------------------------------
        // DBを閉じる
        // ----------------------------------------------------
        public void DBClose()
        {
            // DBを閉じる
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        // ----------------------------------------------------
        // トランザクション開始
        // ----------------------------------------------------
        public void beginTrans()
        {
            if (conn != null)
            {
                trans = conn.BeginTransaction();
            }
        }

        // ----------------------------------------------------
        // トランザクションコミット
        // ----------------------------------------------------
        public void commit()
        {
            trans.Commit();
            trans = null;
        }

        // ----------------------------------------------------
        // トランザクションロールバック
        // ----------------------------------------------------
        public void rollback()
        {
            trans.Rollback();
            trans = null;
        }

        #endregion

        #region "データベース操作処理"

        // ----------------------------------------------------
        // データ検索
        // ----------------------------------------------------
        public DataTable dataFill(string strSQL)
        {
            List<DaoParameter> dummy = new List<DaoParameter>();
            return dataFill(strSQL, dummy);
        }
        public DataTable dataFill(string strSQL, List<DaoParameter> sqlParams)
        {
            // データテーブル（返却値）
            DataTable result = new DataTable();

            // データアダプター
            MySqlDataAdapter dataAdp = new MySqlDataAdapter(strSQL, conn);

            // トランザクション設定
            if (trans != null)
            {
                dataAdp.SelectCommand.Transaction = trans;
            }

            // パラメータ追加
            foreach( DaoParameter param in sqlParams)
            {
                MySqlParameter addParam = makeParameter(param);
                dataAdp.SelectCommand.Parameters.Add(addParam);
            }

            //データ取得
            dataAdp.Fill(result);

            return result;
        }

        // ----------------------------------------------------
        // クエリー実行
        // ----------------------------------------------------
        public int executeQuery(string strSQL)
        {
             List<DaoParameter> dummy = new  List<DaoParameter>();
             return executeQuery(strSQL, dummy);
        }

        public int executeQuery(string strSQL, List<DaoParameter> sqlParams)
        {
            // データアダプター
            MySqlCommand sqlCommand = new MySqlCommand(strSQL, conn);

            // トランザクション設定
            if (trans != null)
            {
                sqlCommand.Transaction = trans;
            }

            // パラメータ追加
            foreach (DaoParameter param in sqlParams)
            {
                MySqlParameter addParam = makeParameter(param);
                sqlCommand.Parameters.Add(addParam);
            }

            //データ取得
            int cnt = sqlCommand.ExecuteNonQuery();

            return cnt;
        }

        // ----------------------------------------------------
        // パラメータ作成
        // ----------------------------------------------------
        private MySqlParameter makeParameter(DaoParameter sqlParam)
        {
            // パラメータ作成
            MySqlParameter param = new MySqlParameter();

            // パラメータ名（バインド変数名）
            param.ParameterName = sqlParam.paramName;

            // パラメータ型
            switch(sqlParam.paramType ) {
                case DaoParameterDataType.typeString:
                    param.MySqlDbType = MySqlDbType.String;
                    break;
                case DaoParameterDataType.typeDate :
                    param.MySqlDbType = MySqlDbType.Date;
                    break;
                case DaoParameterDataType.typeDecimal:
                    param.MySqlDbType = MySqlDbType.Decimal;
                    break;
                default:
                    param.MySqlDbType = MySqlDbType.String;
                    break;
            }

            // パラメータ値
            param.Value = sqlParam.paramValue;

            return param;

        }

        #endregion

    }
}
