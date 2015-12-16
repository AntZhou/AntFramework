namespace Gobang.WPF
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Media;

    using Sudoku.WPF.Annotations;

   

    internal class GobangCellViewModel : INotifyPropertyChanged
    {
        private const int GobangSize = 15;

        public int Row { get; set; } 

        public int Column { get; set; } 

        public int? ChessColor { get; private set; }

        public void SetChessColor(int? color)
        {
            this.ChessColor = color;
            this.OnPropertyChanged(nameof(this.ChessColor));
        }

        public bool ChessVisible => this.ChessColor.HasValue;

        public bool IsNotFirstRow => this.Row != 1;

        public bool IsNotFirstColumn => this.Column != 1;

        public bool IsNotLastRow => this.Row != GobangSize;

        public bool IsNotLastColumn => this.Column != GobangSize;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}