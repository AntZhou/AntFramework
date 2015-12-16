namespace Gobang.Library
{
    using System.Collections.Generic;
    using System.Linq;

    public class GobangChessboard
    {
        private const int BoardSize = 15;

        public GobangChessboard()
        {
            this.Initialize();
        }

        public IList<GobangCell> Cells { get; set; }

        public void Clear()
        {
            foreach (var cell in this.Cells)
            {
                cell.SetColorNumber(null);
            }
        }

        private void Initialize()
        {
            //初始化单元格
            this.Cells = new List<GobangCell>();
            for (var i = 1; i <= BoardSize; i++)
            {
                for (var j = 1; j <= BoardSize; j++)
                {
                    this.Cells.Add(new GobangCell(i, j));
                }
            }
        }

        public GobangCell GetCell(int row, int column)
        {
            return this.Cells.Single(c => c.Row == row && c.Column == column);
        }

        public bool IsSuccessed()
        {
            return false;
        }

        public bool IsWrong()
        {
            return false;
        }
    }
}