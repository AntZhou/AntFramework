namespace Gobang.WPF
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Media;

    using Gobang.Library;

    /// <summary>
    ///     Index.xaml 的交互逻辑
    /// </summary>
    public partial class Index : Page
    {
        public Index()
        {
            this.InitializeComponent();
            this.DrawCell();
        }

        private void DrawCell()
        {
            Player p1 = new Player("Ant");
            Player p2 =new Player("HP");
            var game = GobangGameFactory.CreateGame(new Player[] { p1, p2 });

            const int Size = 15;
            for (int i = 0; i < Size; i++)
            {
                this.BaseGrid.RowDefinitions.Add(new RowDefinition());
                this.BaseGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 1; i <= Size; i++)
            {
                for (int j = 1; j <= Size; j++)
                {
                    GobangCellView view = new GobangCellView();
                    GobangCellViewModel viewModel =new GobangCellViewModel()
                                                       {
                                                           Row = i,
                                                           Column = j,
                                                       };
                    view.DataContext = viewModel;
                    var cell = game.GobangChessboard.GetCell(i, j);
                    cell.ColorNumberChangedEvent += () =>
                        {
                            viewModel.SetChessColor(cell.ColorNumber);
                        };
                    view.MouseLeftButtonDown += (s, e) =>
                        {
                            
                            cell.SetColorNumber(1);
                        };

                    this.BaseGrid.Children.Add(view);
                    view.SetValue(Grid.RowProperty,i-1);
                    view.SetValue(Grid.ColumnProperty,j-1);

                }
            }
        }

       
    }
}