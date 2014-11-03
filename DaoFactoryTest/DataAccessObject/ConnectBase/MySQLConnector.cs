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
        private const string connectionString = "userid=prometheus5481;password=ew873PQM43rw;database=hyperion;Host=localhost;Charset=utf8;";

        // 接続情報
        MySqlConnection conn = null;
        // トランザクション情報
        MySqlTransaction trans = null;

        #region "データベース基本処理"

        // ----------------------------------------------------
        // DBを開く
        // ----------------------------------------------------
        public void DBOpen()
        {
            conn = new MySqlConnection(connectionString);
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

            MySqlParameter param = new MySqlParameter();

            param.ParameterName = sqlParam.paramName;

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
            }

            param.Value = sqlParam.paramValue;

            return param;

        }

        #endregion


    }
}
