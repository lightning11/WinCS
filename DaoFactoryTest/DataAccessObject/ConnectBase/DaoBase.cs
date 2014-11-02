using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DataAccessObject.ConnectBase
{
    public class DaoBase : IDisposable
    {
        // データ接続情報
        IDaoConnector dbCon = null;

        #region "データベース基本処理"

        // データベースを開く
        protected void DBOpen()
        {
            DaoConnectorFactory dbFactory = new DaoConnectorFactory();

            dbCon = dbFactory.create();

            dbCon.DBOpen();

        }

        // データベースを閉じる
        protected void DBClose()
        {
            if (dbCon != null)
            {
                dbCon.DBClose();
            }
        }

        // トランザクション開始
        protected void beginTrans()
        {
            if (dbCon != null)
            {
                dbCon.beginTrans();
            }            
        }

        // トランザクションコミット
        protected void commit()
        {
            if (dbCon != null)
            {
                dbCon.commit();
            }
        }

        // トランザクションロールバック
        protected void rollback()
        {
            if (dbCon != null)
            {
                dbCon.rollback();
            }
        }

        #endregion


        protected DataTable dataFill(string strSQL)
        {
            return dbCon.dataFill(strSQL);
        }

        protected DataTable dataFill(string strSQL, List<DaoParameter> sqlParams)
        {
            return dbCon.dataFill(strSQL, sqlParams);
        }


        #region "コンストラクタ"

        // コンストラクタ
        public DaoBase()
        {
            DBOpen();
        }

        #endregion

        #region "デストラクタ"

        // Dispose したかどうか
        private bool _disposed = false;

        // IDisposable に必須のメソッドの実装
        public void Dispose()
        {
            Dispose(true);
            // Dispose() によってリソースの解放を行ったので、
            // GC での解放が必要が無いことを GC に通知します。
            GC.SuppressFinalize(this);
        }

        // ファイナライザー(デストラクター)
        //
        // Dispose() が呼び出されていない場合のみ
        // 実行されます。
        ~DaoBase()
        {
            Dispose(false);
        }

        
        // このメソッドの呼び出され方は 2 パターンあります。
        // 
        // disposing が true であれば、 Dispose() から呼び出されています。
        //
        // disposing が false であれば、 ファイナライザー(~HtmlFileWriter)
        // から呼び出されています。
        protected virtual void Dispose(bool disposing)
        {
            // Dispose がまだ実行されていないときだけ実行
            if(!_disposed)
            {
                // disposing が true の場合(Dispose() が実行された場合)は
                // マネージリソースも解放します。
                if(disposing)
                {
                    // マネージリソースの解放
                    DBClose();
                }
                
                // アンマネージリソースの解放

                _disposed = true;
            }
        }

        #endregion

    }
}
