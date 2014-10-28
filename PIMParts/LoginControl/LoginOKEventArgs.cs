using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginControl
{
    public class LoginOKEventArgs : EventArgs
    {
        private string m_userName;
        private string m_displayName;

        public LoginOKEventArgs(string userName, string displayName)
        {
            m_userName = userName;
            m_displayName = displayName;
        }

        public string UserName
        {
            get { return m_userName;  }
        }

        public string DisplayName
        {
            get { return m_displayName; }
        }

    }



}
