﻿using System;
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
    /// TestPage2.xaml の相互作用ロジック
    /// </summary>
    public partial class TestPage2 : Page
    {
        public TestPage2()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // Application.Propertiesから受け取る。
            this.paramStr.Content = ((PageParam)Application.Current.Properties["Param"]).paramStr;
        }


    }
}
