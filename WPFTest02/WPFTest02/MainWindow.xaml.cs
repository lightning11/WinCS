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
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        static int _createCount;

        public MainWindow()
        {
            InitializeComponent();

            //this.Topmost = true;
            ////this.Content = "testAA";
            //this.Background = Brushes.Red;

            //Button btnTest = new Button();
            //btnTest.Content = "testets";
            //btnTest.FontSize = 30;

            //Canvas canv = new Canvas();
            //canv.Children.Add(btnTest);

            //this.Content = canv;

            Title = "ウィンドウ" + _createCount;
            _createCount++;


            this.dataGrid.ItemsSource = new[]
            {
                new Person { No = 1, Name = "test1" },
                new Person { No = 2, Name = "test2" }
            };

        }

        private void TestClicked(object sender, RoutedEventArgs e)
        {
            _test1.Text = "testtesttest";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("本当に閉じますか？", "確認", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;

            }
            else
            {
                //ウィンドウを閉じる
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Window openWindow in Application.Current.Windows)
            {
                sb.AppendLine(openWindow.Title);
            }

            MessageBox.Show(sb.ToString(), "Open Windows");
        }
    }
}
