using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.WPF
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Sudoku.WPF.Annotations;

    public class CellViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region 字体大小显示

        private double size = 250;

        public double Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if ((Math.Abs(Math.Abs(value - this.size)) < 0.1))
                {
                    return;
                }
                this.size = value;
                this.OnPropertyChanged(nameof(this.Size));
                this.OnPropertyChanged(nameof(this.SmallFontSize));
            }
        }

        public double SmallFontSize => this.size / 4;

        #endregion

        #region 数字显示

        private int? number;

        public int? Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (this.number == value)
                {
                    return;
                }
                this.number = value;
                this.OnPropertyChanged(nameof(this.Number));
                this.OnPropertyChanged(nameof(this.NumberVisible));
            }
        }

        public bool NumberVisible => this.number.HasValue;

        private List<int> possibleNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public List<int> PossibleNumbers
        {
            get
            {
                return this.possibleNumbers;
            }
            set
            {
                this.possibleNumbers = value;
                this.PossibleNumbersChanged();
            }
        }

        private void PossibleNumbersChanged()
        {
            this.OnPropertyChanged(nameof(this.Number1Visible));
            this.OnPropertyChanged(nameof(this.Number2Visible));
            this.OnPropertyChanged(nameof(this.Number3Visible));
            this.OnPropertyChanged(nameof(this.Number4Visible));
            this.OnPropertyChanged(nameof(this.Number5Visible));
            this.OnPropertyChanged(nameof(this.Number6Visible));
            this.OnPropertyChanged(nameof(this.Number7Visible));
            this.OnPropertyChanged(nameof(this.Number8Visible));
            this.OnPropertyChanged(nameof(this.Number9Visible));
        }

        public bool Number1Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(1);
        public bool Number2Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(2);
        public bool Number3Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(3);
        public bool Number4Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(4);
        public bool Number5Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(5);
        public bool Number6Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(6);
        public bool Number7Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(7);
        public bool Number8Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(8);
        public bool Number9Visible => this.showPossibleNumber && this.PossibleNumbers.Contains(9);

        private bool showPossibleNumber = false;
        public bool ShowPossibleNumber
        {
            get
            {
                return this.showPossibleNumber;
            }
            set
            {
                if (value == this.showPossibleNumber)
                {
                    return;
                }
                this.showPossibleNumber = value;
                this.OnPropertyChanged(nameof(this.ShowPossibleNumber));
            }
        }

        #endregion



    }
}   
