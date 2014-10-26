using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginControl
{
    public partial class Login : UserControl
    {
        public event EventHandler LoginOK;
        public event EventHandler LoginNG;
        public event EventHandler LoginCancel;

        public Login()
        {
            InitializeComponent();
        }

        protected virtual void OnLoginOK()
        {
            if (LoginOK != null)
            {
                LoginOK(this, null);
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
            if ((txtUserName.Text == "test") && (txtPassword.Text == "test"))
            {
                OnLoginOK();
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


    }
}
