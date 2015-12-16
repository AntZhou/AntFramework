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

namespace Sudoku.WPF
{
    using SudokuHelper.Library.Model;

    /// <summary>
    /// CellView.xaml 的交互逻辑
    /// </summary>
    public partial class CellView : UserControl
    {

        public KeyEventHandler InputNumberEvent;
        public CellView()
        {
            this.InitializeComponent();
        }

        private void CellView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.RenderSize = e.NewSize;
            var viewModel = (CellViewModel)this.DataContext;
            viewModel.Size = e.NewSize.Height < e.NewSize.Width ? e.NewSize.Height : e.NewSize.Width;
        }

        private readonly Key[] numberKeys = new Key[] { Key.NumPad1, Key.NumPad2, Key.NumPad3, Key.NumPad4, Key.NumPad5, Key.NumPad6, Key.NumPad7, Key.NumPad8, Key.NumPad9, };
        private void CellView_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!this.numberKeys.Contains(e.Key))
            {
                return;
            }
            this.InputNumberEvent?.Invoke(this, e);
        }
    }
}
