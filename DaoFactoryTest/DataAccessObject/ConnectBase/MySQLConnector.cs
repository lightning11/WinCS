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

        // DBを開く
        public void DBOpen()
        {
            conn = new MySqlConnection(connectionString);
            if (conn != null)
            {
                conn.Open();
            }
        }

        // DBを閉じる
        public void DBClose()
        {
            // DBを閉じる
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }

        // トランザクション開始
        public void beginTrans()
        {
            if (conn != null)
            {
                trans = conn.BeginTransaction();
            }
        }

        // トランザクションコミット
        public void commit()
        {
            trans.Commit();
            trans = null;
        }

        // トランザクションロールバック
        public void rollback()
        {
            trans.Rollback();
            trans = null;
        }


        public DataTable dataFill(string strSQL)
        {
            DataTable result = new DataTable();

            // データアダプター
            MySqlDataAdapter dataAdp = new MySqlDataAdapter(strSQL, conn);

            // トランザクション設定
            if (trans != null)
            {
                dataAdp.SelectCommand.Transaction = trans;
            }

            //データ取得
            dataAdp.Fill(result);


            return result;
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
                MySqlParameter addParam = new MySqlParameter();

                addParam.ParameterName = param.paramName;
                switch(param.paramType ) {
                    case DaoParameterDataType.typeString:
                        addParam.MySqlDbType = MySqlDbType.String;
                        break;
                    case DaoParameterDataType.typeDate :
                        addParam.MySqlDbType = MySqlDbType.Date;
                        break;
                    case DaoParameterDataType.typeDecimal:
                        addParam.MySqlDbType = MySqlDbType.Decimal;
                        break;
                }
                addParam.Value = param.paramValue;

                dataAdp.SelectCommand.Parameters.Add(addParam);
            }

            //データ取得
            dataAdp.Fill(result);


            return result;
        }

    }
}
