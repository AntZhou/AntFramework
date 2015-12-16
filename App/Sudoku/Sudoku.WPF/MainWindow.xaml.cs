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

namespace Sudoku.WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.LoadPage();
            this.InitEvent();
        }

        private void InitEvent()
        {
            this.KeyDown += (s, e) => {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            };
        }
        

        private void LoadPage()
        {
            this.BaseFrame.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}
