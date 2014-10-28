using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginControl;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private void ucLogin_LoginOK(object sender, EventArgs e)
        //{
        //    MessageBox.Show("ログイン成功", "ログイン");
        //}

        private void ucLogin_LoginNG(object sender, EventArgs e)
        {
            MessageBox.Show("ログイン失敗", "ログイン");
        }

        private void ucLogin_LoginCancel(object sender, EventArgs e)
        {
            MessageBox.Show("ログインキャンセル", "ログイン");
        }

        private void ucLogin_LoginOK(object sender, LoginOKEventArgs e)
        {
            MessageBox.Show("ようこそ！ " + e.DisplayName + " さん", "ログイン");
        }




    }
}
