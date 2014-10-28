using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DBConnect
{
    public class DBConnect
    {
        private const string m_connText = "userid=prometheus5481;password=ew873PQM43rw;database=hyperion;Host=localhost;Charset=utf8;";

        private int m_userId = 0;
        private string m_displayName = "";

        public bool Authenticate(string UserName, string Password)
        {
            MySqlConnection conn = null;

            string cmdSQL = "SELECT UserId, DisplayName FROM UserList WHERE Account = '"
                            + UserName + "' AND Password = '" + Password + "'";

            try
            {
                conn = new MySqlConnection(m_connText);
                conn.Open();

                //データを格納するテーブルを作成
                DataTable dt = new DataTable();

                //SQL文と接続情報を指定し、データアダプタを作成
                MySqlDataAdapter da = new MySqlDataAdapter(cmdSQL, conn);

                //データ取得
                da.Fill(dt);

                if (dt.Rows.Count > 0 ) 
                {
                    DataRow row = dt.Rows[0];

                    m_userId = System.Convert.ToInt32(row["UserId"]);
                    m_displayName = (string)row["DisplayName"];
                    
                }
                else
                {
                    m_userId = 0;
                    m_displayName = "";
                    return false;
                }

            }
             catch
            {
                m_userId = 0;
                m_displayName = "";
                return false;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return true;
        }


        public int UserId
        {
            get
            {
                return m_userId;
            }
        }

        public string DisplayName
        {
            get
            {
                return m_displayName;
            }
        }

    }
}
