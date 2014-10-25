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
    public partial class SubForm : Form
    {

        #region プロパティ

        // --------------------------------
        // 数値戻り値
        // --------------------------------
        private int retNum;
        public int RetNum
        {
            get {
                return retNum;
            }
            private set {
                retNum = value;
            }
        }

        #endregion

        #region フォーム

        // --------------------------------
        // 初期処理
        // --------------------------------
        public SubForm()
        {
            InitializeComponent();
        }

        #endregion

        #region ボタンイベント

        // --------------------------------
        // サブ画面閉じるボタン処理
        // --------------------------------
        private void btnClose_Click(object sender, EventArgs e)
        {
            retNum = int.Parse(this.txtNum.Text);

            // 画面を閉じる
            this.Close();
        }

        #endregion

    }
}
