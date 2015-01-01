using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest02
{
    /// <summary>
    /// TestPage1.xaml の相互作用ロジック
    /// </summary>
    public partial class TestPage1 : Page
    {
        public TestPage1()
        {
            InitializeComponent();

            text1.Text = "現在の時刻：" + DateTime.Now.ToString();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            PageParam param = new PageParam() { paramStr = this.ParamText.Text };
            Application.Current.Properties["Param"] = param;
        }
    }
}
