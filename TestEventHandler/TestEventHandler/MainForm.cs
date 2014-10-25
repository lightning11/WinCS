using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEventHandler
{
    public partial class MainForm : Form
    {
        #region フォーム

        // --------------------------------
        // 初期処理
        // --------------------------------
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ボタンイベント

        // --------------------------------
        // サブ画面表示ボタン処理
        // --------------------------------
        private void btnOpenSub_Click(object sender, EventArgs e)
        {
            // サブ画面生成
            SubForm subF = new SubForm();

            // サブ画面が閉じたときのイベントを追加
            subF.FormClosed += new System.Windows.Forms.FormClosedEventHandler(SubFormClosed);

            // サブ画面を開く
            subF.Show();

        }

        #endregion

        #region サブ画面イベント

        // --------------------------------
        // サブ画面が閉じたときのイベント処理
        // --------------------------------
        private void SubFormClosed(object sender, EventArgs e)
        {
            // サブ画面を取得
            SubForm subF = (SubForm)sender;

            // サブ画面で設定した値を取得
            String retStr = subF.RetNum.ToString();

            //サブ画面の値を表示
            MessageBox.Show( retStr
                           , "情報"
                           , MessageBoxButtons.OK );
        }

        #endregion

    }
}
