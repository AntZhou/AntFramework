using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    public class Cell
    {
        public Cell()
        {
            
        }

        public Action NumberChangedEvent;

        public Action PossibleNumbersChangedEvent;
        
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            for (int i = 1; i <= 9; i++)
            {
                this.PossibleNumbers.Add(i);
            }
        }

        public void SetNumber(int number)
        {
            this.Number = number;
            this.PossibleNumbers.Clear();
            this.PossibleNumbersChangedEvent?.Invoke();
            foreach (var group in this.Groups)
            {
                group.OtherCellRemovePossibleNumber(this.Number.Value);
            }
            this.NumberChangedEvent?.Invoke();
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public int? Number { get; set; }

        private List<int> possibleNumbers;

        public List<int> PossibleNumbers
        {
            get
            {
                return this.possibleNumbers ?? (this.possibleNumbers = new List<int>());
            }
            set
            {
                this.possibleNumbers = value;
                this.PossibleNumbersChangedEvent?.Invoke();
                if (this.possibleNumbers?.Count == 1)
                {
                    this.SetNumber(this.possibleNumbers.Single());
                }
            }
        }

        public void RemovePossibleNumber(int num)
        {
            this.PossibleNumbers?.Remove(num);
            this.PossibleNumbersChangedEvent?.Invoke();
        }

        private List<Group> groups;

        public List<Group> Groups
        {
            get
            {
                return this.groups ?? (this.groups = new List<Group>());
            }
            set
            {
                this.groups = value;
            }
        }

        public void Clear()
        {
            this.Number = null;
            this.PossibleNumbers = NumberHelper.AllNumbers.ToList();
            this.NumberChangedEvent?.Invoke();
            this.PossibleNumbersChangedEvent?.Invoke();
        }
    }
}
