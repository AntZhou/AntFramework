using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    using System.Text.RegularExpressions;

    public class Step
    {
        public Step(int row, int column, int number,int index)
        {
            this.Row = row;
            this.Column = column;
            this.Number = number;
            this.Index = index;
        }

        public Step(int rcn, int index)
        {
            if (Regex.IsMatch(rcn.ToString(),"[1-9][1-9][1-9]" ))
            {
                throw new ArgumentException("参数超出范围");
            }
            this.Row = rcn / 100;
            this.Column = (rcn / 10) % 10;
            this.Number = rcn % 10;
            this.Index = index;
        }

        public Step(string xyv,int index)
        {
            if (!Regex.IsMatch(xyv, "[1-9][1-9][1-9]"))
            {
                throw new ArgumentException("参数超出范围");
            }
            int rcn = Convert.ToInt32(xyv);
            this.Row = rcn / 100;
            this.Column = (rcn / 10) % 10;
            this.Number = rcn % 10;
            this.Index = index;
        }

        public int Row { get; }
        public int Column { get; }
        public int Number    { get; }
        public int Index { get; }


        protected bool Equals(Step other)
        {
            return this.Row == other.Row && this.Column == other.Column && this.Number == other.Number ;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.Row;
                hashCode = (hashCode * 397) ^ this.Column;
                hashCode = (hashCode * 397) ^ this.Number;
                return hashCode;
            }
        }
    }   
}
