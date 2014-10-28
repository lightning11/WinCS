using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBConnect;

namespace LoginControl
{
    public delegate void LoginOKEventHandler(object sender, LoginOKEventArgs e);

    public partial class Login : UserControl
    {
        public event LoginOKEventHandler LoginOK;
        public event EventHandler LoginNG;
        public event EventHandler LoginCancel;

        private DBConnect.DBConnect  m_DB;

        public Login()
        {
            InitializeComponent();

            m_DB = new DBConnect.DBConnect();
        }

        protected virtual void OnLoginOK(LoginOKEventArgs e)
        {
            if (LoginOK != null)
            {
                LoginOK(this, e);
            }
        }

        protected virtual void OnLoginNG()
        {
            if (LoginNG != null)
            {
                LoginNG(this, null);
            }
        }

        protected virtual void OnLoginCancel()
        {
            if (LoginCancel != null)
            {
                LoginCancel(this, null);
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {

            bool result = m_DB.Authenticate(txtUserName.Text, txtPassword.Text);

            if (result)
            {
                LoginOKEventArgs le = new LoginOKEventArgs(txtUserName.Text, m_DB.DisplayName);

                OnLoginOK(le);
            }
            else
            {
                OnLoginNG();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            OnLoginCancel();
        }

        public DBConnect.DBConnect conDB
        {
            get { return m_DB; }
        }

    }
}
