using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class Chessboard
    {
        public Chessboard()
        {
            this.Initialize();
        }

        public void Clear()
        {
            foreach (var cell in this.Cells)
            {
                cell.Clear();
            }
        }

        private void Initialize()
        {
            //初始化单元格
            this.Cells = new List<Cell>();
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    this.Cells.Add(new Cell(i,j));
                }
            }
            //初始化组别
            this.Groups = new List<Group>();
            for (int i = 1; i <= 9; i++)
            {
                this.Groups.Add(new Group(this.Cells.Where(s => s.Row == i).ToList(), $"row{i}")); 
                this.Groups.Add(new Group(this.Cells.Where(s => s.Column == i).ToList(),$"column{i}"));
            }
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row <= 3 && s.Column <= 3).ToList(), "square1"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row <= 3 && s.Column >= 4 && s.Column <= 6).ToList(), "square2"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row <= 3 && s.Column >= 7 ).ToList(), "square3"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 4 && s.Row <= 6 && s.Column <= 3).ToList(), "square4"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 4 && s.Row <= 6 && s.Column >= 4 && s.Column <= 6).ToList(), "square5"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 4 && s.Row <= 6 && s.Column >= 7).ToList(), "square6"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 7 && s.Column <= 3).ToList(), "square7"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 7 && s.Column >= 4 && s.Column <= 6).ToList(), "square8"));
            this.Groups.Add(new Group(this.Cells.Where(s => s.Row >= 7 && s.Column >= 7).ToList(), "square9"));
        }

        public IList<Group> Groups { get; set; } 

        public IList<Cell> Cells { get; set; }

        public Cell GetCell(int row, int column)
        {
            return this.Cells.Single(c => c.Row == row && c.Column == column);
        }

        public Group GetGroup(int row, int column, int square)
        {
            if (row > 0 && row < 10)
            {
                return this.Groups.Single(g => g.Name == $"row{row}");
            }
            if (column > 0 && column < 10)
            {
                return this.Groups.Single(g => g.Name == $"column{column}");
            }
            if (square > 0 && square < 10)
            {
                return this.Groups.Single(g => g.Name == $"square{square}");
            }
            return null;
        }

        public bool IsSuccessed()
        {
            return this.Groups.All(currentGroup => currentGroup.IsSuccessed());
        }

        public bool IsWrong()
        {
            return this.Groups.Any(l => !l.IsSuccessed());
        }


    }
}
