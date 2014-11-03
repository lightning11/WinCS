using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessObject.Dao;
using DataAccessObject.Data;

namespace DaoFactoryTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (DaoUserList test = new DaoUserList())
                {
                    System.Diagnostics.Debug.WriteLine("スタート！");

                    DataTable aa = test.selectAllUserList();

                    dgvUserList.DataSource = aa;
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message, "ログイン");
            }
            finally
            {

            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (DaoUserList test = new DaoUserList())
                {
                    DDaoUserList insData = new DDaoUserList();

                    insData.userId = 30;
                    insData.account = "addtest";
                    insData.password = "test";
                    insData.displayName = "追加太郎";

                    int cnt = test.insertUserList(insData);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ログイン");
            }
            finally
            {

            }

        }
    }
}
