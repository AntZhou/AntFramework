namespace Gobang.Library
{
    using System;
    using System.Collections.Generic;

    public class GobangCell
    {
        public Action ColorNumberChangedEvent;

        public GobangCell()
        {
        }

        public GobangCell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int? ColorNumber { get; private set; }

        public void SetColorNumber(int? colorNumber)
        {
            this.ColorNumber = colorNumber;
            this.ColorNumberChangedEvent?.Invoke();
        }

    }
}