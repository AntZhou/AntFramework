using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuHelper.Library.Model
{
    using Gobang.WPF;

    public class Group
    {
        public Group()
        {
            this.Cells = new List<Cell>();
        }

        public Group(List<Cell> cells,string name = "")
        {
            this.Cells = cells;
            this.Name = name;
            foreach (var cell in cells)
            {
                var currentCell = cell;
                currentCell.Groups.Add(this);
            }
        }

        public string Name { get; set; }

        public List<Cell> Cells { get; set; }

        private List<int> ApearedNumbers => (from cell in this.Cells where cell.Number.HasValue select cell.Number.Value).ToList();

        private List<int> UnApearedNumbers => NumberHelper.AllNumbers.Except(this.ApearedNumbers).ToList();

        public void OtherCellRemovePossibleNumber(int number)
        {
            foreach (var otherCell in this.Cells.Where(c=>!c.Number.HasValue))
            {
                var currentCell = otherCell;
                currentCell.RemovePossibleNumber(number);
            }
        }

        public void SingleNumberCheck()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (this.Cells.Count(c => c.PossibleNumbers.Contains(i))==1)
                {
                    this.Cells.Single(c => c.PossibleNumbers.Contains(i)).SetNumber(i);
                }
            }
        }

        /// <summary>
        /// 根据合集去除可能值 比如有如下可能值（1、2）（1、3）（2、3）（1、4、5）的4个单元格。前三个单元格可能值合集为（1、2、3）该合集子集有3个，意味着（1、2、3）只能分布在这三个单元格中，所以（1、4、5）这个子集需要排除掉可能值1
        /// </summary>
        public void CollectionCheck()
        {
            //排除掉可能值数量与该分组未确定值数量相同的单元格
            //比如该分组有5个值未确定，这个单元格有5个可能值，它与任何单元格的合集都是5个可能值，最终5个值只能分布在5个未确定单元格内，无意义。
            //只有小于5个可能值的合集，才能排除剩余单元格可能值
            var handlingCells = this.Cells.Where(c => !c.Number.HasValue && c.PossibleNumbers.Count < this.UnApearedNumbers.Count).ToList();
            for (int i = 0; i < handlingCells.Count; i++)
            {
                //合集
                List<int> collection = new List<int>();
                if (this.ExpandCollectionSuccessed(handlingCells, collection, i))
                {
                    return;
                }
            }
            
        }

        private bool ExpandCollectionSuccessed(List<Cell> handlingCells, List<int> collection, int i)
        {
            //子集匹配数量
            int matched;
            do
            {
                var currentCell = handlingCells[i];
                collection.AddRange(currentCell.PossibleNumbers);
                collection = collection.Distinct().ToList();
                //不存在可能值在合集之外
                matched =
                    handlingCells.Count(
                        currentOtherCell => !currentOtherCell.PossibleNumbers.Exists(p => !collection.Contains(p)));
                i++;
            }
            while (collection.Count != this.UnApearedNumbers.Count && collection.Count != matched && i< handlingCells.Count);
            if (collection.Count == this.UnApearedNumbers.Count || collection.Count != matched)
            {
                return false;
            }
            this.UpdatePossibleNumberByCollection(collection);
            return true;
        }

        private void UpdatePossibleNumberByCollection(List<int> collection)
        {
            var list = this.Cells.Where(currentCell => currentCell.PossibleNumbers.Any() && currentCell.PossibleNumbers.Exists(p => !collection.Contains(p)))
                .ToList();
            foreach (var cell in list)
            {
                foreach (var i in collection)
                {
                    cell.RemovePossibleNumber(i);
                }
            }
        }

        public void HiddenNumberCheck()
        {
            var handlingCells = this.Cells.Where(c => !c.Number.HasValue).ToList();
            foreach (var currentNumber in this.UnApearedNumbers)
            {
                var list = handlingCells.Where(h => h.PossibleNumbers.Contains(currentNumber));
                List<Group> otherGroups = new List<Group>();
                foreach (var cell in list)
                {
                    if (!otherGroups.Any())
                    {
                        otherGroups.AddRange(cell.Groups);
                    }
                    else
                    {
                        otherGroups = otherGroups.Intersect(cell.Groups).ToList();
                    }
                }
                if (!otherGroups.Any())
                {
                    continue;
                }
                foreach (var otherGroup in otherGroups)
                {
                    otherGroup.OtherCellRemovePossibleNumber(currentNumber, handlingCells);
                }
            }

        }

        /// <summary>
        ///     去掉可能值
        /// </summary>
        /// <param name="currentNumber">可能值</param>
        /// <param name="exceptCells">不处理单元格</param>
        private void OtherCellRemovePossibleNumber(int currentNumber, List<Cell> exceptCells)
        {
            var list = this.Cells.Where(c => !c.Number.HasValue).Except(exceptCells);
            foreach (var otherCell in list)
            {
                var currentCell = otherCell;
                currentCell.RemovePossibleNumber(currentNumber);
            }
        }

        public bool IsSuccessed()
        {
            return !this.UnApearedNumbers.Any();
        }
    }
}
