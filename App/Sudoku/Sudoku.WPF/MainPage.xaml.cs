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
    using Ant.Core;

    using SudokuHelper.Library.Model;

    /// <summary>
    /// TestPage.xaml 的交互逻辑
    /// </summary>
    public partial class MainPage : Page
    {
        private Chessboard chessboard ;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainPage_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.RenderSize = e.NewSize;
        }

        private void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            this.LoadChessboard();
            this.LoadCells();
        }

        

        private void LoadChessboard()
        {
            this.chessboard = ChessboardFactory.CreateChessboard("#1");
        }

        private void LoadCells()
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    CellView view = new CellView();
                    var viewModel = new CellViewModel();
                    var cell = this.chessboard.GetCell(i, j);

                    if (cell.Number.HasValue)
                    {
                        viewModel.Number = cell.Number;
                    }
                    viewModel.PossibleNumbers = cell.PossibleNumbers;

                    cell.NumberChangedEvent += () => { viewModel.Number = cell.Number; };
                    cell.PossibleNumbersChangedEvent += () => { viewModel.PossibleNumbers = cell.PossibleNumbers; };
                    view.InputNumberEvent += (v,e) => cell.SetNumber(e.Key.ToString().ToInt());
                    view.DataContext = viewModel;
                    this.BaseGrid.Children.Add(view);
                    view.SetValue(Grid.RowProperty, i - 1);
                    view.SetValue(Grid.ColumnProperty, j - 1);
                }
            }
        }

        private void SetCellValueBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int row = this.TextBoxRow.Text.ToInt();
            int column = this.TextBoxColumn.Text.ToInt();
            int number = this.TextBoxValue.Text.ToInt();
            this.chessboard.GetCell(row,column).SetNumber(number);
        }

        private void GroupSinglePossibleCheckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int row = this.GroupRow.Text.ToInt();
            int column = this.GroupColumn.Text.ToInt();
            int square = this.GroupSquare.Text.ToInt();
            var group = this.chessboard.GetGroup(row, column, square);
            group.SingleNumberCheck();
        }

        private void GroupCollectionCheckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            int row = this.GroupRow.Text.ToInt();
            int column = this.GroupColumn.Text.ToInt();
            int square = this.GroupSquare.Text.ToInt();
            var group = this.chessboard.GetGroup(row, column, square);
            group.CollectionCheck();
        }

        private void AllSingleCheckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.chessboard.Groups.ToList().ForEach(l=>l.SingleNumberCheck());
        }

        private void AllCollectionCheckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.chessboard.Groups.ToList().ForEach(l => l.CollectionCheck());
        }

        private void HiddenNumberCheckBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.chessboard.Groups.ToList().ForEach(l=>l.HiddenNumberCheck());
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.chessboard = ChessboardFactory.CreateChessboard("#1");
        }

        //private int groupIndex=0;
        private void OtherTestBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.chessboard.Clear();
        }

       
    }
}
