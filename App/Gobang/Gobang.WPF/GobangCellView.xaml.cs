namespace Gobang.WPF
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    ///     GobangCellView.xaml 的交互逻辑
    /// </summary>
    public partial class GobangCellView : UserControl
    {
        public GobangCellView()
        {
            this.InitializeComponent();
        }

        private void GobangCell_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var viewModel = this.ViewModel;
        }

        private void UserControlMouseEnter(object sender, MouseEventArgs e)
        {
            this.BaseGrid.Background = new SolidColorBrush(Colors.Coral);
        }

        private void UserControlMouseLeave(object sender, MouseEventArgs e)
        {
            this.BaseGrid.Background = App.ChessboardColorBrush;
        }
        
    }
}