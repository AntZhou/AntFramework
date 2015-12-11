namespace SudokuHelper.Library.Model
{
    using System.Collections.Generic;
    using System.Linq;

    public class ChessManual
    {
        public string ChessManualNumber { get; set; }

        private List<Step> stepList;

        public List<Step> StepList
        {
            get
            {
                return this.stepList ?? (this.stepList = new List<Step>());
            }
            set
            {
                this.stepList = value;
            }
        }

        public bool Push(Step step)
        {
            if (this.StepList.Exists(s => s.Equals(step)))
            {
                return false;
            }
            this.StepList.Add(step);
            return true;
        }

        public bool GoBack()
        {
            if (!this.StepList.Any())
            {
                return false;
            }
            this.StepList.Remove(this.StepList.Last());
            return true;
        }
    }
}